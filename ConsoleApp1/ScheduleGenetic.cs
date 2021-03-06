﻿using ConsoleApp1.TimetableDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum AlgorithmState
    {
        AS_USER_STOPED,
        AS_CRITERIA_STOPPED,
        AS_RUNNING
    }
    // Algorithm's observer
    public class ScheduleObserver
    {


        // Event that blocks caller until algorithm finishes execution 
        EventWaitHandle _event;

        // Window which displays schedule
        private ChildView _window;

        // Called when algorithm starts execution
        private void BlockEvent()
        {
            _event.Reset();
        }

        // Called when algorithm finishes execution
        private void ReleaseEvent()
        {
            _event.Set();
        }


        // Initializes observer
        public ScheduleObserver()
        {
            this._window = null;
            _event = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        // Frees used resources
        public void Dispose()
        {
            _event.Close();
        }

        // Block caller's thread until algorithm finishes execution
        public void WaitEvent()
        {
            _event.WaitOne();
        }

        // Handles event that is raised when algorithm finds new best chromosome

        public void NewBestChromosome(ScheduleGenetic newChromosome)
        {
            if (_window != null)
            {
                _window.SetSchedule(newChromosome);
            }
        }

        // Handles event that is raised when state of execution of algorithm is changed

        // Handles event that is raised when state of execution of algorithm is changed
        public void EvolutionStateChanged(AlgorithmState newState)
        {
            if (_window != null)
            {
                _window.SetNewState(newState);
            }
            //newState != AS_RUNNING ? ReleaseEvent() : BlockEvent();
            if (newState != AlgorithmState.AS_RUNNING)
                ReleaseEvent();
            else BlockEvent();

        }

        // Sets window which displays schedule
        public void SetWindow(ChildView window)
        {
            _window = window;
        }

    }

    // Schedule chromosome
    public class ScheduleGenetic
    {

        // Number of crossover points of parent's class tables
        private int _numberOfCrossoverPoints;

        // Number of classes that is moved randomly by single mutation operation
        private int _mutationSize;

        // Probability that crossover will occure
        private int _crossoverProbability;

        // Probability that mutation will occure
        private int _mutationProbability;

        // Fitness value of chromosome
        private float _fitness;

        // Flags of class requiroments satisfaction
        private List<bool> _criteria = new List<bool>();

        // Time-space slots, one entry represent one hour in one classroom
        private List<List<DataRow>> _slots = new List<List<DataRow>>(DefineConstants.DAYS_NUM * DefineConstants.DAY_HOURS * Counts.GetInstance().GetNumberOfRooms());

        // Class table for chromosome
        // Used to determine first time-space slot used by class
        private Dictionary<DataRow, int> _classes = new Dictionary<DataRow, int>();


        // Initializes chromosomes with configuration block (setup of chromosome)
        public ScheduleGenetic(int numberOfCrossoverPoints, int mutationSize, int crossoverProbability, int mutationProbability)
        {
            this._mutationSize = mutationSize;
            this._numberOfCrossoverPoints = numberOfCrossoverPoints;
            this._crossoverProbability = crossoverProbability;
            this._mutationProbability = mutationProbability;
            this._fitness = 0F;
            // reserve space for time-space slots in chromosomes code
            _slots.Resize(DefineConstants.DAYS_NUM * DefineConstants.DAY_HOURS * Counts.GetInstance().GetNumberOfRooms());
            // reserve space for flags of class requirements
            _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 9);
        }

        // Copy constructor
        public ScheduleGenetic(ScheduleGenetic c, bool setupOnly)
        {
            if (!setupOnly)
            {
                // copy code
                _slots = new List<List<DataRow>>(c._slots);
                _classes = c._classes;

                // copy flags of class requirements
                _criteria = new List<bool>(c._criteria);

                // copy fitness
                _fitness = c._fitness;
            }
            else
            {
                // reserve space for time-space slots in chromosomes code
                _slots.Resize(DefineConstants.DAYS_NUM * DefineConstants.DAY_HOURS * Counts.GetInstance().GetNumberOfRooms());

                // reserve space for flags of class requirements
                _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 9);
            }

            // copy parameters
            _numberOfCrossoverPoints = c._numberOfCrossoverPoints;
            _mutationSize = c._mutationSize;
            _crossoverProbability = c._crossoverProbability;
            _mutationProbability = c._mutationProbability;
        }


        // Makes copy of chromosome

        public ScheduleGenetic MakeCopy(bool setupOnly)
        {
            // make object by calling copy constructor and return smart pointer to new object
            return new ScheduleGenetic(this, setupOnly);
        }

        // Makes new chromosome with same setup but with randomly chosen code
        public ScheduleGenetic MakeNewFromPrototype()
        {
            // number of time-space slots
            int size = _slots.Count;
            ScheduleGenetic newChromosome = new ScheduleGenetic(this, true);
            DataTable rooms = Counts.GetInstance().GetRooms();
            DataTable lectureRooms = Counts.GetInstance().GetLectureRooms();
            DataTable labRooms = Counts.GetInstance().GetLabRooms();
            int numLabRooms = Counts.GetInstance().GetNumberOfLabRooms();
            int numLectureRooms = Counts.GetInstance().GetNumberOfLectureRooms();
            // DataTable c = Counts.GetInstance().getCourseClassesWithNullValues();
            DataTable c = Counts.GetInstance().GetCourseClasses();
            int nr = Counts.GetInstance().GetNumberOfRooms();
            int daySize = DefineConstants.DAY_HOURS * nr;
            Console.WriteLine("New Chromosome");
            Counts counts = new Counts();
            foreach (DataRow courseRow in c.Rows)
            {
                // determine random position of class
                int dur = Int32.Parse(courseRow["duration"].ToString());
                int day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                int room;
                int randroom;
                if (courseRow["preferredRoom"] != DBNull.Value)// .Equals(null))
                {
                    room = Int32.Parse(courseRow["preferredRoom"].ToString());
                    randroom = rooms.Rows.IndexOf(rooms.Rows.Find(room));
                }
                else
                {
                    randroom = RandomNumbers.NextNumber() % nr;
                    for (int i = 0; i < 2; i++)
                    {
                        randroom = RandomNumbers.NextNumber() % nr;
                        if (courseRow["lab"].Equals(true))
                            room = Int32.Parse(labRooms.Rows[randroom % numLabRooms]["id"].ToString());
                        else
                            room = Int32.Parse(lectureRooms.Rows[randroom % numLectureRooms]["id"].ToString());
                        int roomSeats = counts.GetRoomMaxCapicityById(room);
                        int classSeats = counts.GetCourseStudents(Int32.Parse(courseRow["courseId"].ToString()));
                        if (roomSeats >= classSeats) break;
                    }

                }
                int counter =0;
                int time;
                int pos;
                do
                {
                    time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                    if (time % 2 != 0) time -= 1;
                    pos = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                    counter++;
                    if (newChromosome._slots[pos] == null)
                        break;
                    if (newChromosome._slots[pos].Count == 0)
                        break;
                    if (pos < _slots.Count - 7)
                    {
                        if (newChromosome._slots[pos + 4] == null)
                        {
                            if (time + 4 < DefineConstants.DAY_HOURS + 1 - dur)
                            {
                                time = time + 4;
                                pos = pos + 4;
                                break;
                            }
                        }
                    }
                    if (pos > 4 && time > 4) { 
                    if (newChromosome._slots[pos - 4] == null)
                        {
                            if (time - 4 < DefineConstants.DAY_HOURS + 1 - dur)
                            {
                                time = time - 4;
                                pos = pos - 4;
                                break;
                            }
                        }
                    }
                    if (pos < _slots.Count - 5)
                    {
                        if (newChromosome._slots[pos + 2] == null)
                        {
                            if (time + 2 < DefineConstants.DAY_HOURS + 1 - dur)
                            {
                                time = time + 2;
                                pos = pos + 2;
                                break;
                            }
                        }
                    }
                    if (pos > 2 && time>2)
                    {
                        if (newChromosome._slots[pos - 2] == null)
                        {
                            if (time - 2 < DefineConstants.DAY_HOURS + 1 - dur)
                            {
                                time = time - 2;
                                pos = pos - 2;
                                break;
                            }
                        }
                    }
                } while (counter < 6);
                //pos = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                // fill time-space slots, for each hour of class
                // List<DataRow> l = new List<DataRow>();
                for (int i = dur - 1; i >= 0; i--)
                {
                    List<DataRow> l = new List<DataRow>();
                    l.Add(courseRow);
                    if (newChromosome._slots[(pos + i)] == null)
                        newChromosome._slots[(pos + i)] = l;
                    else
                        newChromosome._slots[(pos + i)].Add(courseRow);
                    // newChromosome._slots.Insert((pos + i), l);

                }
                newChromosome._classes.Add(courseRow, pos);
            }





            newChromosome.CalculateFitness();

            // return smart pointer
            return newChromosome;
        }

        // Performes crossover operation using to chromosomes and returns pointer to offspring

        public ScheduleGenetic Crossover(ScheduleGenetic parent2)
        {
            // check probability of crossover operation
            if (RandomNumbers.NextNumber() % 100 > _crossoverProbability)
            {
                // no crossover, just copy first parent
                return new ScheduleGenetic(this, false);
            }

            // new chromosome object, copy chromosome setup
            ScheduleGenetic n = new ScheduleGenetic(this, true);

            // number of classes
            int size = (int)_classes.Count();
            List<bool> cp = new List<bool>(new bool[size]);
            // limit trial times to only 5 times if not found then exit
            int counter = 0;
            // determine crossover point (randomly) where it's not in the middle of a class time in both parents
            for (int i = _numberOfCrossoverPoints; i > 0; i--)
            {
                while (counter < 5)
                {
                    int p = RandomNumbers.NextNumber() % size;
                    if (!cp[p] && (_classes.ElementAt(p).Equals(null) || _slots[p] == null) && (parent2._classes.ElementAt(p).Equals(null) || parent2._slots[p] == null))
                    {
                        cp[p] = true;
                        break;
                    }
                    counter++;
                }
            }
            // make new code by combining parent codes
            bool first = RandomNumbers.NextNumber() % 2 == 0;
            for (int j = 0; j < size; j++)
            {
                if (first)
                {
                    // insert class from first parent into new chromosome's calss table
                    var it1 = _classes.ElementAt(j);
                    DataRow cc1 = it1.Key;
                    List<DataRow> l = new List<DataRow>();
                    l.Add(cc1);
                    n._classes.Add(it1.Key, it1.Value);
                    // all time-space slots of class are copied
                    for (int i = Int32.Parse(it1.Key["duration"].ToString()) - 1; i >= 0; i--)
                    {
                        if (n._slots[it1.Value + i] == null)
                            n._slots[it1.Value + i] = l;
                        else
                            n._slots[it1.Value + i].Add(cc1);
                    }
                }
                else
                {
                    var it2 = parent2._classes.ElementAt(j);
                    DataRow cc2 = it2.Key;
                    List<DataRow> l = new List<DataRow>();
                    l.Add(cc2);
                    // insert class from second parent into new chromosome's calss table
                    n._classes.Add(it2.Key, it2.Value);
                    // all time-space slots of class are copied
                    for (int i = Int32.Parse(it2.Key["duration"].ToString()) - 1; i >= 0; i--)
                    {
                        if (n._slots[it2.Value + i] == null)
                            n._slots[it2.Value + i] = l;
                        else
                            n._slots[it2.Value + i].Add(cc2);
                        //n._slots[it2.Value + i].AddLast(cc2);

                    }
                }

                // crossover point
                if (cp[j])
                {
                    // change soruce chromosome
                    first = !first;
                }
            }

            //n.CalculateFitness();
            //Console.WriteLine("hill climbing");
            n.CalculateFitness();
            n = HillClimbing.solve(n);
            //n = SimulatedAnnealing.StartAnnealing(n);
            n.CalculateFitness();
            // return smart pointer to offspring
            return n;
        }

        // Performs mutation on chromosome
        public void Mutation()
        {
            // check probability of mutation operation
            if (RandomNumbers.NextNumber() % 100 > _mutationProbability)
                return;

            // number of classes
            int numberOfClasses = (int)_classes.Count();
            // number of time-space slots
            int size = (int)_slots.Count;
            Counts counts = new Counts();
            DataTable rooms = counts.GetRooms();
            // move selected number of classes at random position
            for (int j = _mutationSize; j > 0; j--)
            {
                // select random chromosome for movement
                int mpos = RandomNumbers.NextNumber() % numberOfClasses;
                int pos1 = 0;
                int d = 0;
                // for (; mpos > 0; it.MoveNext(), mpos--)
                for (; mpos > 0; ++d, mpos--)
                {
                    ;
                }
                // current time-space slot used by class
                var it = _classes.ElementAt(d);
                pos1 = it.Value;

                DataRow cc1 = it.Key;

                // determine position of class randomly
                int nr = Counts.GetInstance().GetNumberOfRooms();
                int dur = Int32.Parse(cc1["duration"].ToString());
                int day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                int randroom = RandomNumbers.NextNumber() % nr;
                int room;//= Int32.Parse(rooms.Rows[randroom]["id"].ToString());
                if (cc1["preferredRoom"] != DBNull.Value)// .Equals(null))
                {
                    room = Int32.Parse(cc1["preferredRoom"].ToString());
                    randroom = rooms.Rows.IndexOf(rooms.Rows.Find(room));
                }
                else
                {
                    randroom = RandomNumbers.NextNumber() % nr;
                    for (int i = 0; i < 2; i++)
                    {
                        randroom = RandomNumbers.NextNumber() % nr;
                        if (cc1["lab"].Equals(true))
                            room = Int32.Parse(rooms.Rows[randroom % rooms.Rows.Count]["id"].ToString());
                        else
                            room = Int32.Parse(rooms.Rows[randroom % rooms.Rows.Count]["id"].ToString());
                        int roomSeats = counts.GetRoomMaxCapicityById(room);
                        int classSeats = counts.GetCourseStudents(Int32.Parse(cc1["courseId"].ToString()));
                        if (roomSeats >= classSeats) break;
                    }
                }
                int time;
                int pos2;
                int counter = 0;// = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                //if (time % 2 != 0) time -= 1;
                do
                {
                    time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                    if (time % 2 != 0) time -= 1;
                    pos2 = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                    counter++;
                    if (_slots[pos2] == null ) break;
                } while (counter < 4);
                //int pos2 = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;

                // move all time-space slots
                for (int i = dur - 1; i >= 0; i--)
                {
                    // remove class hour from current time-space slot
                    List<DataRow> cl = _slots[pos1 + i];
                    foreach (DataRow r in cl)
                    {

                        if (r == cc1)
                        {
                            cl.Remove(r);
                            break;
                        }
                    }

                    // move class hour to new time-space slot
                    if (_slots[pos2 + i] == null)
                    {
                        List<DataRow> l = new List<DataRow>();
                        l.Add(cc1);
                        _slots[pos2 + i] = l;
                    }
                    else
                        _slots[pos2 + i].Add(cc1);
                    // _slots[pos2 + i].AddLast(cc1);
                }

                // change entry of class table to point to new time-space slots
                _classes[cc1] = pos2;
            }

            CalculateFitness();
        }

        // Calculates fitness value of chromosome

        public void CalculateFitness()
        {
            // chromosome's score
            int score = 0;

            int numberOfRooms = Counts.GetInstance().GetNumberOfRooms();
            int daySize = DefineConstants.DAY_HOURS * numberOfRooms;
            Counts counts = new Counts();
            DataTable rooms = counts.GetRooms();
            //DataTable labs = counts.GetLabRooms();

            //double arrays for each year and devision
            int[,] fm = new int[5, 5];
            int[,] fmcs = new int[5, 5];
            int[,] fs = new int[5, 5];
            int[,] fscs = new int[5, 5];
            int[,] fit = new int[5, 5];
            int[,] fcs = new int[5, 5];

            int[,] sm = new int[5, 5];
            int[,] smcs = new int[5, 5];
            int[,] ss = new int[5, 5];
            int[,] sscs = new int[5, 5];
            int[,] sit = new int[5, 5];
            int[,] scs = new int[5, 5];

            int[,] tm = new int[5, 5];
            int[,] tmcs = new int[5, 5];
            int[,] ts = new int[5, 5];
            int[,] tscs = new int[5, 5];
            int[,] tit = new int[5, 5];
            int[,] tcs = new int[5, 5];

            int[,] fom = new int[5, 5];
            int[,] fomcs = new int[5, 5];
            int[,] fos = new int[5, 5];
            int[,] foscs = new int[5, 5];
            int[,] foit = new int[5, 5];
            int[,] focs = new int[5, 5];

            int[,] fifm = new int[5, 5];
            int[,] fifmcs = new int[5, 5];
            int[,] fifs = new int[5, 5];
            int[,] fifscs = new int[5, 5];
            int[,] fifit = new int[5, 5];
            int[,] fifcs = new int[5, 5];

            int ci = 0;

            // check criterias and calculate scores for each class in schedule
            //for (Dictionary<DataRow, int>.Enumerator it = _classes.GetEnumerator(); !it.Equals(_classes.Last()); it.MoveNext(), ci += 8)
            foreach (KeyValuePair<DataRow, int> it in _classes)
            {

                // coordinate of time-space slot
                int p = it.Value;
                int day = p / daySize;
                int time = p % daySize;
                //the randomly generated room index
                int randroom = time / DefineConstants.DAY_HOURS;
                //the real index of the room in the DB
                int classRoom = Int32.Parse(rooms.Rows[randroom]["id"].ToString());

                time = time % DefineConstants.DAY_HOURS;
                int dur = Int32.Parse(it.Key["duration"].ToString());
                int currentClassId = Int32.Parse(it.Key["courseId"].ToString());
                // check for room overlapping of classes
                bool ro = false;
                for (int i = dur - 1; i >= 0; i--)
                {
                    if (_slots[p + i] != null && _slots[p + i].Count > 1)
                    {
                        ro = true;
                        break;
                    }
                }

                // Hard constraint on room not overlaping nothing happens
                //if (!ro)
                //    score++;
                if (ro)
                    score -= 200;
                _criteria[ci + 0] = !ro;

                DataRow cc = it.Key;
                DataRow r = Counts.GetInstance().GetRoomById(classRoom);
                int roomSeats = counts.GetRoomMaxCapicityById(classRoom);
                int classSeats = counts.GetCourseStudents(currentClassId);

                // does current room have enough seats
                _criteria[ci + 1] = roomSeats >= classSeats;
                // Hard constraint when satisfied nothing happens nothing happens
                //if (_criteria[ci + 1])
                //    score++;
                if (!_criteria[ci + 1])
                    score -= 200;
                // does current room have computers if they are required
                Boolean roomLab = Convert.ToBoolean(rooms.Rows[randroom]["lab"].ToString().ToLower());
                Boolean classLab = Boolean.Parse(cc["lab"].ToString());
                _criteria[ci + 2] = !classLab || (classLab && roomLab);
                // Hard constraint when satisfied nothing happens nothing happens
                //if (_criteria[ci + 2])
                //    score++;
                if (!_criteria[ci + 2])
                    score -= 200;
                bool po = false;
                bool go = false;
                // check overlapping of classes for professors and student groups
                for (int i = numberOfRooms, t = day * daySize + time; i > 0; i--, t += DefineConstants.DAY_HOURS)
                {
                    // for each hour of class
                    for (int j = dur - 1; i >= 0; i--)
                    {
                        // check for overlapping with other classes at same time
                        List<DataRow> cl = _slots[t + j];
                        if (cl != null)
                        {
                            foreach (DataRow crow in cl)
                            {
                                if (cc != crow)
                                {
                                    // professor overlaps?
                                    if (counts.GetClassInstructor(Int32.Parse(cc["courseId"].ToString())) == counts.GetClassInstructor(Int32.Parse(crow["courseId"].ToString())))
                                    {
                                        po = true;
                                    }

                                    // student group overlaps?

                                    DataTable curClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(cc["courseId"].ToString()));
                                    DataTable sameTimeClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(crow["courseId"].ToString()));
                                    curClassCurriculums.Columns.Remove("courseId");
                                    sameTimeClassCurriculums.Columns.Remove("courseId");
                                    int[] curClassCurriculumsIds = new int[curClassCurriculums.Rows.Count];
                                    int[] sameTimeClassCurriculumsIds = new int[sameTimeClassCurriculums.Rows.Count];
                                    int count = 0;
                                    foreach (DataRow id in curClassCurriculums.Rows)
                                    {
                                        curClassCurriculumsIds[count]=Int32.Parse(id["curriculumId"].ToString());
                                        count++;
                                    }
                                    count = 0;
                                    foreach (DataRow id in sameTimeClassCurriculums.Rows)
                                    {
                                        sameTimeClassCurriculumsIds[count] = Int32.Parse(id["curriculumId"].ToString());
                                        count++;
                                    }
                                    var intersection =curClassCurriculumsIds.Intersect(sameTimeClassCurriculumsIds);
                                    if (!go && curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()).Count() !=0) //intersection.Count() !=0)//
                                    {
                                        go = true;
                                    }

                                    // both type of overlapping? no need to check more
                                    if (po && go)
                                    {
                                        goto total_overlap;
                                    }
                                }
                            }
                        }
                    }

                    total_overlap:

                    // professors have no overlaping classes?

                    // Hard constraint when satisfied nothing happens nothing happens
                    //if (!po)
                    //    score++;

                    if (po)
                        score -= 200;
                    _criteria[ci + 3] = !po;

                    // student groups has no overlaping classes?
                    // Hard constraint when satisfied nothing happens nothing happens
                    //if (!go)
                    //    score++;
                    if (go)
                        score -= 200;
                    _criteria[ci + 4] = !go;
                }
                // instructors preferred time
                int[] instructorId = counts.GetClassInstructor(currentClassId);
                DataTable dt = counts.GetInstructorPreferredTime(instructorId);
                bool insPrefTime = false;
                foreach (DataRow t in dt.Rows)
                {
                    int pDay = Int32.Parse(t["day"].ToString());
                    int pTimeBegin = Int32.Parse(t["timeStart"].ToString());
                    int pTimeEnd = Int32.Parse(t["timeEnd"].ToString());
                    if (day == pDay && time >= pTimeBegin && time <= pTimeEnd)
                        insPrefTime = true;
                }
                if (insPrefTime)
                    score++;
                _criteria[ci + 5] = insPrefTime;

                //preferred room for lecture
                bool pr = false;
                if (cc["preferredRoom"] == null)
                    pr = true;
                else
                    if (cc["preferredRoom"] == cc["roomId"])
                    pr = true;
                if (pr) score++;
                _criteria[ci + 6] = pr;

                //Lab and Lecture morning or evening sessions
                bool labeven = false;
                bool lectMorn = false;
                if (Convert.ToBoolean(cc["lab"]))
                {
                    if (time >= 12)
                        labeven = true;
                }
                else
                {
                    if (time < 12)
                        lectMorn = true;
                }
                if (labeven) score++;
                if (lectMorn) score++;
                _criteria[ci + 7] = labeven;
                _criteria[ci + 8] = lectMorn;
                //To know the max hours per day and if a specific group have a day off
                // they must be grouped, insert the data in arrays
                int h;
                if (Convert.ToBoolean(cc["lab"]) == false)
                    h = 1;
                else h = 2;
                DataTable yd = counts.GetClassYandD(Int32.Parse(cc["courseId"].ToString()));
                DataRow row = yd.Rows[0];
                int outt = 0;
                // to know to wich time block it belongs
                int timeBlock = time / 2;
                if (Int32.TryParse(row["cs"].ToString(), out outt))// != -1)
                {

                    switch (Int32.Parse(row["cs"].ToString()))
                    {
                        case 1:
                            fcs[day, timeBlock] = h;
                            break;
                        case 2:
                            scs[day, timeBlock] = h;
                            break;
                        case 3:
                            tcs[day, timeBlock] = h;
                            break;
                        case 4:
                            focs[day, timeBlock] = h;
                            break;
                        case 5:
                            fifcs[day, timeBlock] = h;
                            break;

                    }
                    //if (Int32.Parse(row["cs"].ToString()) == 1)
                    //    fcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["cs"].ToString()) == 2)
                    //    scs[day, timeBlock] = h;
                    //if (Int32.Parse(row["cs"].ToString()) == 3)
                    //    tcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["cs"].ToString()) == 4)
                    //    focs[day, timeBlock] = h;
                    //if (Int32.Parse(row["cs"].ToString()) == 5)
                    //    fifcs[day, timeBlock] = h;
                }
                if (Int32.TryParse(row["math"].ToString(), out outt))// != -1)
                {
                    switch (Int32.Parse(row["math"].ToString()))
                    {
                        case 1:
                            fm[day, timeBlock] = h;
                            break;
                        case 2:
                            sm[day, timeBlock] = h;
                            break;
                        case 3:
                            tm[day, timeBlock] = h;
                            break;
                        case 4:
                            fom[day, timeBlock] = h;
                            break;
                        case 5:
                            fifm[day, timeBlock] = h;
                            break;

                    }
                    //if (Int32.Parse(row["math"].ToString()) == 1)
                    //    fm[day, timeBlock] = h;
                    //if (Int32.Parse(row["math"].ToString()) == 2)
                    //    sm[day, timeBlock] = h;
                    //if (Int32.Parse(row["math"].ToString()) == 3)
                    //    tm[day, timeBlock] = h;
                    //if (Int32.Parse(row["math"].ToString()) == 4)
                    //    fom[day, timeBlock] = h;
                    //if (Int32.Parse(row["math"].ToString()) == 5)
                    //    fifm[day, timeBlock] = h;
                }
                if (Int32.TryParse(row["mathCS"].ToString(), out outt))// != -1)
                {
                    switch (Int32.Parse(row["mathCS"].ToString()))
                    {
                        case 1:
                            fmcs[day, timeBlock] = h;
                            break;
                        case 2:
                            smcs[day, timeBlock] = h;
                            break;
                        case 3:
                            tmcs[day, timeBlock] = h;
                            break;
                        case 4:
                            fomcs[day, timeBlock] = h;
                            break;
                        case 5:
                            fifmcs[day, timeBlock] = h;
                            break;

                    }
                    //    if (Int32.Parse(row["mathCS"].ToString()) == 1)
                    //    fmcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["mathCS"].ToString()) == 2)
                    //    smcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["mathCS"].ToString()) == 3)
                    //    tmcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["mathCS"].ToString()) == 4)
                    //    fomcs[day, timeBlock] = h;
                    //if (Int32.Parse(row["mathCS"].ToString()) == 5)
                    //    fifmcs[day, timeBlock] = h;
                }
                if (Int32.TryParse(row["stat"].ToString(), out outt))// != -1)
                {
                    switch (Int32.Parse(row["stat"].ToString()))
                    {
                        case 1:
                            fs[day, timeBlock] = h;
                            break;
                        case 2:
                            ss[day, timeBlock] = h;
                            break;
                        case 3:
                            ts[day, timeBlock] = h;
                            break;
                        case 4:
                            fos[day, timeBlock] = h;
                            break;
                        case 5:
                            fifs[day, timeBlock] = h;
                            break;

                    }

                    //if (Int32.Parse(row["stat"].ToString()) == 1)
                    //    fs[day, timeBlock] = h;
                    //if (Int32.Parse(row["stat"].ToString()) == 2)
                    //    ss[day, timeBlock] = h;
                    //if (Int32.Parse(row["stat"].ToString()) == 3)
                    //    ts[day, timeBlock] = h;
                    //if (Int32.Parse(row["stat"].ToString()) == 4)
                    //    fos[day, timeBlock] = h;
                    //if (Int32.Parse(row["stat"].ToString()) == 5)
                    //    fifs[day, timeBlock] = h;
                }
                if (Int32.TryParse(row["statCS"].ToString(), out outt))// != -1)
                {
                    switch (Int32.Parse(row["statCS"].ToString()))
                    {
                        case 1:
                            fscs[day, timeBlock] = h;
                            break;
                        case 2:
                            sscs[day, timeBlock] = h;
                            break;
                        case 3:
                            tscs[day, timeBlock] = h;
                            break;
                        case 4:
                            foscs[day, timeBlock] = h;
                            break;
                        case 5:
                            fifscs[day, timeBlock] = h;
                            break;

                    }
                    //if (Int32.Parse(row["statCS"].ToString()) == 1)
                    //    fscs[day, timeBlock] = h;
                    //if (Int32.Parse(row["statCS"].ToString()) == 2)
                    //    sscs[day, timeBlock] = h;
                    //if (Int32.Parse(row["statCS"].ToString()) == 3)
                    //    tscs[day, timeBlock] = h;
                    //if (Int32.Parse(row["statCS"].ToString()) == 4)
                    //    foscs[day, timeBlock] = h;
                    //if (Int32.Parse(row["statCS"].ToString()) == 5)
                    //    fifscs[day, timeBlock] = h;
                }
                if (Int32.TryParse(row["IT"].ToString(), out outt))// != "-1")
                {
                    switch (Int32.Parse(row["IT"].ToString()))
                    {
                        case 1:
                            fit[day, timeBlock] = h;
                            break;
                        case 2:
                            sit[day, timeBlock] = h;
                            break;
                        case 3:
                            tit[day, timeBlock] = h;
                            break;
                        case 4:
                            foit[day, timeBlock] = h;
                            break;
                        case 5:
                            fifit[day, timeBlock] = h;
                            break;

                    }
                    //if (Int32.Parse(row["IT"].ToString()) == 1)
                    //    fit[day, timeBlock] = h;
                    //if (Int32.Parse(row["IT"].ToString()) == 2)
                    //    sit[day, timeBlock] = h;
                    //if (Int32.Parse(row["IT"].ToString()) == 3)
                    //    tit[day, timeBlock] = h;
                    //if (Int32.Parse(row["IT"].ToString()) == 4)
                    //    foit[day, timeBlock] = h;
                    //if (Int32.Parse(row["IT"].ToString()) == 5)
                    //    fifit[day, timeBlock] = h;
                }


                ci += 9;
            }

            //then call a function and send it all the years and devisions
            //then for each devision of a year whom don't have an off day
            //or consecutive hours more than 6 increment the score 
            List<int[,]> data = new List<int[,]> { fm/*, fmcs, fs, fscs, fcs, */, fit, sm, /*smcs, ss, sscs, scs,*/sit, tm/*, tmcs, ts, tscs, tcs*/, tit, fom, fomcs, fos, foscs, focs, foit, fifm, fifmcs, fifs, fifscs, fifcs, fifit };
            List<string> dataNames = new List<string> { "first", "firstIT", "second", "secondIT", "third", "thirdIT", "fourthMATH", "fourthMATHCS", "fourthSTAT", "fourthSTATCS","fourthCS", "fourthIT", "fifthMATH", "fifthMATHCS", "fifthSTAT", "fifthSTATCS", "fifthCS","fifthIT" };
            score += CheckPref(data, dataNames);
            //calculate fitess value based on score
            _fitness = (float)score / (Counts.GetInstance().GetNumberOfCourseClasses() * DefineConstants.DAYS_NUM);
        }
        private int CheckPref(List<int[,]> allData, List<string> allDataNames)
        {
            int score = 0;
            for (int i = 0; i < allData.Count; i++)
                score += CheckSoftPref(allData[i], allDataNames[i]);
            return score;
        }
        //see if the they have a day off + see the maximum hours they are working in
        private int CheckSoftPref(int[,] yd, string name)
        {
            //work here get the day off preferences for each year
            DataTable pref = Counts.GetInstance().GetStudentsPrefrences(name);
            string prefDay = pref.Rows[0]["DayOff"].ToString();
            bool labLectureSameDay = Convert.ToBoolean(pref.Rows[0]["LabLectureSameDay"]);
            bool lectureMorningSession = Convert.ToBoolean(pref.Rows[0]["LectureMorningSession"]);
            //work here see if the lab and days on same day or not;
            int score = 0;
            int consectiveHours = 0;
            bool consHours6 = false;
            bool consHours4 = false;
            bool[] days = new bool[7];
            bool prefDayOff = false;
            bool dayOff = false;
            bool labsAndLecturesSameDay = false;
            //calculate the number of lectures and labs in a single day
            int numOfLectures = 0;
            int numOfLabs = 0;
            for (int d = 0; d <= 4; d++)
            {
                consectiveHours = 0;
                for (int t = 0; t <= 4; t++)
                {
                    //1 for lectures
                    if (yd[d, t] == 1)
                    {
                        consectiveHours += 2;
                        days[d] = true;
                        numOfLectures++;
                    }
                    else if (yd[d, t] == 2)
                    {
                        consectiveHours += 2;
                        days[d] = true;
                        numOfLabs++;
                    }
                    else
                        consectiveHours = 0;

                }
                if (consectiveHours >= 6)
                    consHours6 = true;
                if (consectiveHours >= 4)
                    consHours4 = true;
                //work if day have both
                if (numOfLectures != 0 && numOfLabs != 0)
                    labsAndLecturesSameDay = true;
            }
            //off day
            if (days.Contains(false))
            {
                dayOff = true;
                //get the indexes of all off days if any 
                var result = Enumerable.Range(0, days.Count()).Where(i => days[i] == false).ToList();
                //check if the off day is the preferred one or not !
                int intIndexOfPrefDay = 8;
                if (Enum.IsDefined(typeof(DayOfWeek), prefDay))
                {
                    DayOfWeek x = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), prefDay, true);
                    intIndexOfPrefDay = (int)x;
                }
                if (result.Contains(intIndexOfPrefDay)) prefDayOff = true; ;
            }

            //consecetive hourse
            if (consHours4 == false)
                score++;
            else
            {
                if (consHours6 == false)
                    score++;
            }
            //checkForOffDay
            if (dayOff == true)
                score++;
            //check if the day off is the preferred day
            if (prefDayOff == true)
                score++;
            if (labsAndLecturesSameDay == labLectureSameDay)
                score++;
            return score;
        }

        //get the current timetables and evaluate
        public void evaluate()
        {
            _2ndTermUniversityScheduleTableAdapter sched = new _2ndTermUniversityScheduleTableAdapter();
            DataTable sem = sched.GetData();
            DataRow classDR;
            Counts counts = new Counts();
            DataTable rooms = counts.GetRooms();
            int nr = Counts.GetInstance().GetNumberOfRooms();
            int daySize = DefineConstants.DAY_HOURS * nr;
            DataTable labRooms = counts.GetLabRooms();
            DataTable lectureRooms = counts.GetLectureRooms();
            foreach (DataRow r in sem.Rows)
            {
                int curClassId = Int32.Parse(r["courseClassId"].ToString());
                classDR = counts.GetClassById(curClassId);
                int startTime = Int32.Parse(r["time start"].ToString());
                int time = startTime - 8;
                int dur = Int32.Parse(classDR["duration"].ToString());
                String d = r["day"].ToString();
                int room = Int32.Parse(r["roomId"].ToString());
                int randroom;
                randroom = rooms.Rows.IndexOf(rooms.Rows.Find(room));
                //if (classDR["lab"].Equals(true))
                //  randroom = labRooms.Rows.IndexOf(labRooms.Rows.Find(room));
                //randroom = room % numLabRooms;
                // else
                //  randroom = lectureRooms.Rows.IndexOf(lectureRooms.Rows.Find(room));
                int t = randroom * DefineConstants.DAY_HOURS;
                int day = 8;
                if (Enum.IsDefined(typeof(DayOfWeek), d))
                {
                    DayOfWeek x = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d, true);
                    day = (int)x;
                }
                //int pos = day * daySize;
                int ptime = startTime - 8;
                int pos = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                // fill time-space slots, for each hour of class
                for (int i = dur - 1; i >= 0; i--)
                {
                    List<DataRow> l = new List<DataRow>();
                    l.Add(classDR);
                    if (_slots[(pos + i)] == null)
                        _slots[(pos + i)] = l;
                    else
                        _slots[(pos + i)].Add(classDR);
                    // newChromosome._slots.Insert((pos + i), l);

                }
                _classes.Add(classDR, pos);
            }
            CalculateFitness();
            float score = GetFitness();
            Console.WriteLine("The fitness is " + score);

        }
        // Returns fitness value of chromosome
        public float GetFitness()
        {
            return _fitness;
        }

        // Returns reference to table of classes
        public Dictionary<DataRow, int> GetClasses()
        {
            return _classes;
        }

        // Returns array of flags of class requiroments satisfaction
        public List<bool> GetCriteria()
        {
            return _criteria;
        }

        // Return reference to array of time-space slots
        public List<List<DataRow>> GetSlots()
        {
            return _slots;
        }

    }

    // Genetic algorithm
    public class Algorithm
    {


        // Population of chromosomes
        private List<ScheduleGenetic> _chromosomes = new List<ScheduleGenetic>();

        // Inidicates wheahter chromosome belongs to best chromosome group
        private List<bool> _bestFlags = new List<bool>();

        // Indices of best chromosomes
        private List<int> _bestChromosomes = new List<int>();

        // Number of best chromosomes currently saved in best chromosome group
        private int _currentBestSize;

        // Number of chromosomes which are replaced in each generation by offspring
        private int _replaceByGeneration;

        // Pointer to algorithm observer
        private ScheduleObserver _observer;

        // Prototype of chromosomes in population
        private ScheduleGenetic _prototype;

        // Current generation
        private int _currentGeneration;

        // State of execution of algorithm
        private AlgorithmState _state;

        // Synchronization of algorithm's state
        public static object _stateSect = new Object();
        // private CCriticalSection _stateSect = new CCriticalSection();

        // Pointer to global instance of algorithm
        private static Algorithm _instance = null;

        // Synchronization of creation and destruction of global instance
        public static object _instanceSect = new Object();
        // private static CCriticalSection _instanceSect = new CCriticalSection();

        // Synchronization of creation and destruction of global instance

        private static SemaphoreSlim @lock;
        //static Thread @thr;
        public static Algorithm GetInstance()
        {

            @lock = new SemaphoreSlim(1);
            //CCriticalSectionSim.LockData();
            // Thread @thr;
            // global instance doesn't exist?
            @lock.Wait();
            if (_instance == null)
            {
                //@thr = new Thread(new delegate() { GetInstance(); });
                // set seed for random generator
                RandomNumbers.Seed((int)DateTime.Now.Ticks);

                // make prototype of chromosomes
                ScheduleGenetic prototype = new ScheduleGenetic(2, 2, 80, 3);

                // make new global instance of algorithm using chromosome prototype
                _instance = new Algorithm(100, 8, 5, prototype, new ScheduleObserver());


            }

            return _instance;
        }

        // Frees memory used by gloval instance

        public static void FreeInstance()
        {
            //CSingleLock @lock = new CSingleLock(_instanceSect, 1);
            @lock = new SemaphoreSlim(1);
            @lock.Wait();

            // free memory used by global instance if it exists
            if (_instance != null)
            {
                _instance._prototype = null;
                _instance._observer.Dispose();
                _instance = null;

            }
        }

        // Initializes genetic algorithm
        public Algorithm(int numberOfChromosomes, int replaceByGeneration, int trackBest, ScheduleGenetic prototype, ScheduleObserver observer)
        {
            this._replaceByGeneration = replaceByGeneration;
            this._currentBestSize = 0;
            this._prototype = prototype;
            this._observer = observer;
            this._currentGeneration = 0;
            this._state = new AlgorithmState();
            this._state = AlgorithmState.AS_USER_STOPED;
            // there should be at least 2 chromosomes in population
            if (numberOfChromosomes < 2)
            {
                numberOfChromosomes = 2;
            }

            // and algorithm should track at least on of best chromosomes
            if (trackBest < 1)
            {
                trackBest = 1;
            }

            if (_replaceByGeneration < 1)
            {
                _replaceByGeneration = 1;
            }
            else if (_replaceByGeneration > numberOfChromosomes - trackBest)
            {
                _replaceByGeneration = numberOfChromosomes - trackBest;
            }

            // reserve space for population
            _chromosomes.Resize(numberOfChromosomes);
            _bestFlags.Resize(numberOfChromosomes);

            // reserve space for best chromosome group
            _bestChromosomes.Resize(trackBest);

            // clear population
            for (int i = (int)_chromosomes.Count - 1; i >= 0; --i)
            {
                _chromosomes[i] = null;
                _bestFlags[i] = false;
            }
        }

        // Starts and executes algorithm
        public void Start()
        {
            if (_prototype == null)
                return;

            //CSingleLock @lock = new CSingleLock(_stateSect, 1);
            @lock = new SemaphoreSlim(1);
            @lock.Wait();
            // do not run already running algorithm
            if (_state == AlgorithmState.AS_RUNNING)
                return;

            _state = AlgorithmState.AS_RUNNING;

            @lock.Release();
            //@lock.Close();

            if (_observer != null)
            {
                // notify observer that execution of algorithm has changed it state
                _observer.EvolutionStateChanged(_state);
            }

            // clear best chromosome group from previous execution
            ClearBest();

            // initialize new population with chromosomes randomly built using prototype
            List<ScheduleGenetic> it = _chromosomes.ToList();
            ScheduleGenetic snew;
            for (int i = 0; i < it.Count; i++)
            {
                // remove chromosome from previous execution
                if (it[i] != null)
                {
                    if (!it[i].Equals(null))
                    {
                        it[i] = null;
                    }
                }

                // add new chromosome to population
                //if population empty inser if into _chromosomes
                snew = _prototype.MakeNewFromPrototype();
                if (_chromosomes[i] == null)
                    _chromosomes[i] = snew;
                it[i] = snew;
                //    it[i] = _prototype.MakeNewFromPrototype();
                AddToBest(i);
            }
            _currentGeneration = 0;

            while (true)
            {
                @lock.Wait();
                // user has stopped execution?
                if (_state != AlgorithmState.AS_RUNNING)
                {
                    @lock.Release();
                    break;
                }

                ScheduleGenetic best = GetBestChromosome();
                Console.WriteLine("check if best found" + best.GetFitness());
                // work algorithm has reached criteria?
                if (best.GetFitness() >= 0)
                {
                    Counts counts = new Counts();
                    ScheduleTableAdapter sched = new ScheduleTableAdapter();
                    DataTable rooms = counts.GetRooms();
                    _state = AlgorithmState.AS_CRITERIA_STOPPED;
                    //for (Dictionary<DataRow, int>.Enumerator x = best.GetClasses().GetEnumerator(); !it.Equals(best.GetClasses().Last()); x.MoveNext())
                    //{
                    foreach (KeyValuePair<DataRow, int> x in best.GetClasses())
                    {
                        // coordinate of time-space slot
                        int nr = Counts.GetInstance().GetNumberOfRooms();
                        int daySize = DefineConstants.DAY_HOURS * nr;
                        int p = x.Value;
                        int day = p / daySize;
                        int time = p % daySize;
                        int room = time / DefineConstants.DAY_HOURS;
                        int timeEnd;
                        time = time % DefineConstants.DAY_HOURS;
                        //int pos = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                        int dur = Int32.Parse(x.Key["duration"].ToString());
                        int classId = Int32.Parse(x.Key["id"].ToString());
                        int roomId = Int32.Parse(rooms.Rows[room]["Id"].ToString());
                        //0 = sunday and so on
                        String d = ((DayOfWeek)day).ToString();
                        time = time + 8;
                        timeEnd = time + dur;
                        sched.Insert(classId, d, time, timeEnd, roomId);
                    }
                    Console.Write("done");
                    @lock.Release();
                    break;
                }

                @lock.Release();
                Console.WriteLine("produce offepsing");
                // produce offepsing
                List<ScheduleGenetic> offspring = new List<ScheduleGenetic>();
                offspring.Resize(_replaceByGeneration);
                for (int j = 0; j < _replaceByGeneration; j++)
                {
                    // selects parent randomly
                    ScheduleGenetic p1 = _chromosomes[RandomNumbers.NextNumber() % _chromosomes.Count];
                    ScheduleGenetic p2 = _chromosomes[RandomNumbers.NextNumber() % _chromosomes.Count];
                    Console.WriteLine("produce offepsing: Crossover");
                    offspring[j] = p1.Crossover(p2);
                    Console.WriteLine("produce offepsing: Mutation");
                    offspring[j].Mutation();
                   // Console.WriteLine("produce offepsing: Simulated Annealling");
                    //offspring[j] = SimulatedAnnealing.StartAnnealing(offspring[j]);
                }
                Console.WriteLine("replace chromosomes of current operation with offspring");
                // replace chromosomes of current operation with offspring
                for (int j = 0; j < _replaceByGeneration; j++)
                {
                    int ci;
                    do
                    {
                        // select chromosome for replacement randomly
                        ci = RandomNumbers.NextNumber() % (int)_chromosomes.Count;

                        // protect best chromosomes from replacement
                    } while (IsInBest(ci));

                    // replace chromosomes
                    if (_chromosomes[ci] != null)
                        _chromosomes[ci] = null;
                    _chromosomes[ci] = offspring[j];

                    // try to add new chromosomes in best chromosome group
                    AddToBest(ci);
                }

                // algorithm has found new best chromosome
                if (best != GetBestChromosome() && _observer != null)
                {
                    // notify observer
                    _observer.NewBestChromosome(GetBestChromosome());
                }

                _currentGeneration++;
            }

            if (_observer != null)
            {
                // notify observer that execution of algorithm has changed it state
                _observer.EvolutionStateChanged(_state);
            }
        }

        // Stops execution of algoruthm

        // Stops execution of algoruthm
        public void Stop()
        {
            @lock = new SemaphoreSlim(1);
            @lock.Wait();
            if (_state == AlgorithmState.AS_RUNNING)
            {
                _state = AlgorithmState.AS_USER_STOPED;
            }

            @lock.Release();
        }

        // Returns pointer to best chromosomes in population

        // Returns pointer to best chromosomes in population
        public ScheduleGenetic GetBestChromosome()
        {
            return _chromosomes[_bestChromosomes[0]];
        }

        // Returns current generation
        public int GetCurrentGeneration()
        {
            return _currentGeneration;
        }

        // Return to algorithm's observer
        public ScheduleObserver GetObserver()
        {
            return _observer;
        }


        // Tries to add chromosomes in best chromosome group
        private void AddToBest(int chromosomeIndex)
        {
            // don't add if new chromosome hasn't fitness big enough for best chromosome group
            // or it is already in the group?
            if ((_currentBestSize == (int)_bestChromosomes.Count() &&
                _chromosomes[_bestChromosomes[_currentBestSize - 1]].GetFitness() >=
                _chromosomes[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
                return;

            // find place for new chromosome
            int i = _currentBestSize;
            for (; i > 0; i--)
            {
                // group is not full?
                if (i < (int)_bestChromosomes.Count())
                {
                    // position of new chromosomes is found?
                    if (_chromosomes[_bestChromosomes[i - 1]].GetFitness() >
                        _chromosomes[chromosomeIndex].GetFitness())
                        break;

                    // move chromosomes to make room for new
                    _bestChromosomes[i] = _bestChromosomes[i - 1];
                }
                else
                    // group is full remove worst chromosomes in the group
                    _bestFlags[_bestChromosomes[i - 1]] = false;
            }

            // store chromosome in best chromosome group
            _bestChromosomes[i] = chromosomeIndex;
            _bestFlags[chromosomeIndex] = true;
            // increase current size if it has not reached the limit yet
            if (_currentBestSize < (int)_bestChromosomes.Count())
                _currentBestSize++;
            Console.WriteLine("0:" + _chromosomes[_bestChromosomes[0]].GetFitness().ToString());
            Console.WriteLine("1:" + _chromosomes[_bestChromosomes[1]].GetFitness().ToString());
            Console.WriteLine("2:" + _chromosomes[_bestChromosomes[2]].GetFitness().ToString());
            Console.WriteLine("3:" + _chromosomes[_bestChromosomes[3]].GetFitness().ToString());
            Console.WriteLine("4:" + _chromosomes[_bestChromosomes[4]].GetFitness().ToString());
            ////if start up population best is empty
            //if (_currentBestSize == 0)
            //{
            //    _bestChromosomes[_currentBestSize] = chromosomeIndex;
            //    _bestFlags[chromosomeIndex] = true;
            //    _currentBestSize++;
            //}
            //// don't add if new chromosome hasn't fitness big enough for best chromosome group
            //// or it is already in the group?
            //else
            //{
            //    if ((_currentBestSize == (int)_bestChromosomes.Count && _chromosomes[_bestChromosomes[_currentBestSize - 1]].GetFitness() >= _chromosomes[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
            //        return;

            //    // find place for new chromosome
            //    int i = _currentBestSize;
            //    for (; i > 0; i--)
            //    {
            //        // group is not full?
            //        if (i < (int)_bestChromosomes.Count)
            //        {
            //            // position of new chromosomes is found?
            //            if (_chromosomes[_bestChromosomes[i - 1]].GetFitness() > _chromosomes[chromosomeIndex].GetFitness())
            //                break;

            //            // move chromosomes to make room for new
            //            _bestChromosomes[i] = _bestChromosomes[i - 1];
            //        }
            //        else
            //        {
            //            // group is full remove worst chromosomes in the group
            //            _bestFlags[_bestChromosomes[i - 1]] = false;
            //        }
            //    }

            //    // store chromosome in best chromosome group
            //    _bestChromosomes[i] = chromosomeIndex;
            //    _bestFlags[chromosomeIndex] = true;

            //    // increase current size if it has not reached the limit yet
            //    if (_currentBestSize < (int)_bestChromosomes.Count)
            //    {
            //        _currentBestSize++;
            //    }          
            //}
            //for (int z = 0; z < _currentBestSize; z++)
            //    Console.WriteLine(_chromosomes[_bestChromosomes[z - 1]].GetFitness());
        }
        // Returns TRUE if chromosome belongs to best chromosome group
        private bool IsInBest(int chromosomeIndex)
        {
            return _bestFlags[chromosomeIndex];
        }

        // Clears best chromosome group
        private void ClearBest()
        {
            if (_bestFlags.Contains(true))
            {
                for (int i = (int)_bestFlags.Count - 1; i >= 0; --i)
                {
                    _bestFlags[i] = false;
                }
            }

            _currentBestSize = 0;
        }

    }
}
