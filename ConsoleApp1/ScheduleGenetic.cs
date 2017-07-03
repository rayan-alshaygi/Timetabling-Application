using ConsoleApp1.TimetableDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

        //C++ TO C# CONVERTER TODO TASK: C# has no concept of a 'friend' class:
        //	friend class ScheduleObserver;


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
        private List<List<DataRow>> _slots = new List<List<DataRow>>();

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
            _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 8
 );
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
                _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 8);
            }

            // copy parameters
            _numberOfCrossoverPoints = c._numberOfCrossoverPoints;
            _mutationSize = c._mutationSize;
            _crossoverProbability = c._crossoverProbability;
            _mutationProbability = c._mutationProbability;
        }

        // Makes copy ot chromosome

        // Makes copy ot chromosome
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: Schedule* MakeCopy(bool setupOnly) const
        public ScheduleGenetic MakeCopy(bool setupOnly)
        {
            // make object by calling copy constructor and return smart pointer to new object
            return new ScheduleGenetic(this, setupOnly);
        }

        // Makes new chromosome with same setup but with randomly chosen code

        // Makes new chromosome with same setup but with randomly chosen code
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: Schedule* MakeNewFromPrototype() const
        public ScheduleGenetic MakeNewFromPrototype()
        {
            // number of time-space slots
            int size = _slots.Count;
            ScheduleGenetic newChromosome = new ScheduleGenetic(this, true);
            DataTable rooms = Counts.GetInstance().GetLectureRooms();
            DataTable labs = Counts.GetInstance().GetLabRooms();

            // place classes at random position
            DataTable c = Counts.GetInstance().GetCourseClasses();
            int nr = Counts.GetInstance().GetNumberOfLectureRooms();
            int nl = Counts.GetInstance().GetNumberOfLabRooms();
            //variable needed in searching for instructors and curriculums over lap
            int daySize = DefineConstants.DAY_HOURS * nr;
            Console.WriteLine("before entering");
            Console.WriteLine(c.Rows.Count);
            Console.WriteLine(rooms.Rows.Count);
            foreach (DataRow courseRow in c.Rows)
            {
                Console.WriteLine("currently working in course" + courseRow["Id"]);
                // determine random position of class
                int dur = Int32.Parse(courseRow["duration"].ToString());
                int day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                int room;
                // determine if it's a lab or a lecture
                if (Boolean.Parse(courseRow["lab"].ToString()) == false)
                    room = RandomNumbers.NextNumber() % nr;
                else
                    room = RandomNumbers.NextNumber() % nl;
                int time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                int pos = day * nr * DefineConstants.DAY_HOURS + room * DefineConstants.DAY_HOURS + time;
                Console.WriteLine("picked random numbers");

                // fill time-space slots, for each hour of class
                List<DataRow> l = new List<DataRow>();
                for (int i = dur - 1; i >= 0; i--)
                {
                    l.Add(courseRow);
                    newChromosome._slots.Insert((pos + i), l);

                }
                newChromosome._classes.Add(courseRow, pos);
                //insert it into the schedule class
                //int classId = Int32.Parse(courseRow["id"].ToString());
                //int roomId = Int32.Parse(rooms.Rows[room]["Id"].ToString());
                ////0 = sunday and so on
                //String d = ((DayOfWeek)day).ToString();
                //time = time + 8;
                //sched.Insert(classId, d, time, roomId);
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
            List<bool> cp = new List<bool>(size);

            // determine crossover point (randomly)
            for (int i = _numberOfCrossoverPoints; i > 0; i--)
            {
                while (true)
                {
                    int p = RandomNumbers.NextNumber() % size;
                    if (!cp[p])
                    {
                        cp[p] = true;
                        break;
                    }
                }
            }
            Dictionary<DataRow, int>.Enumerator it1 = _classes.GetEnumerator();
            //Dictionary<DataRow int>.const_iterator  = _classes.begin();
            Dictionary<DataRow, int>.Enumerator it2 = parent2._classes.GetEnumerator();
            // Dictionary<CourseClass*, int>.const_iterator it2 = parent2._classes.begin();

            // make new code by combining parent codes
            bool first = RandomNumbers.NextNumber() % 2 == 0;
            for (int j = 0; j < size; j++)
            {
                if (first)
                {
                    // insert class from first parent into new chromosome's calss table
                    n._classes.Add(it1.Current.Key, it1.Current.Value);
                    // all time-space slots of class are copied
                    for (int i = Int32.Parse(it1.Current.Key["duration"].ToString()) - 1; i >= 0; i--)
                    {
                        n._slots[it1.Current.Value + i].Add(it1.Current.Key);
                    }
                }
                else
                {
                    // insert class from second parent into new chromosome's calss table
                    n._classes.Add(it2.Current.Key, it2.Current.Value);
                    // all time-space slots of class are copied
                    for (int i = Int32.Parse(it2.Current.Key["duration"].ToString()) - 1; i >= 0; i--)
                    {
                        n._slots[it2.Current.Value + i].Add(it2.Current.Key);
                    }
                }

                // crossover point
                if (cp[j])
                {
                    // change soruce chromosome
                    first = !first;
                }
                it1.MoveNext();
                it2.MoveNext();
            }

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

            // move selected number of classes at random position
            for (int j = _mutationSize; j > 0; j--)
            {
                // select ranom chromosome for movement
                int mpos = RandomNumbers.NextNumber() % numberOfClasses;
                int pos1 = 0;
                Dictionary<DataRow, int>.Enumerator it = _classes.GetEnumerator();
                for (; mpos > 0; it.MoveNext(), mpos--)
                {
                    ;
                }

                // current time-space slot used by class
                pos1 = it.Current.Value;

                DataRow cc1 = it.Current.Key;

                // determine position of class randomly
                int nr = Counts.GetInstance().GetNumberOfRooms();
                int dur = Int32.Parse(cc1["duration"].ToString());
                int day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                int room = RandomNumbers.NextNumber() % nr;
                int time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                int pos2 = day * nr * DefineConstants.DAY_HOURS + room * DefineConstants.DAY_HOURS + time;

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
                    _slots[pos2 + i].Add(cc1);
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
            DataTable rooms = counts.GetLectureRooms();
            DataTable labs = counts.GetLabRooms();

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
            for (Dictionary<DataRow, int>.Enumerator it = _classes.GetEnumerator(); !it.Equals(_classes.Last()); it.MoveNext(), ci += 8)
            {
                // coordinate of time-space slot
                int p = it.Current.Value;
                int day = p / daySize;
                int time = p % daySize;
                int room = time / DefineConstants.DAY_HOURS;
                time = time % DefineConstants.DAY_HOURS;
                Console.WriteLine("current value"+it.Current.Value);
                Console.WriteLine("current duration " +it.Current.Key["duration"]);
                int dur = Int32.Parse(it.Current.Key["duration"].ToString());

                // check for room overlapping of classes
                bool ro = false;
                for (int i = dur - 1; i >= 0; i--)
                {
                    if (_slots[p + i].Count > 1)
                    {
                        ro = true;
                        break;
                    }
                }

                // Hard constraint on room not overlaping nothing happens
                //if (!ro)
                //    score++;
                if (ro)
                    score -= 16;
                _criteria[ci + 0] = !ro;

                DataRow cc = it.Current.Key;
                DataRow r = Counts.GetInstance().GetRoomById(room);
                int roomSeats = Int32.Parse(rooms.Rows[room]["numberofseats"].ToString());
                int classSeats = counts.GetCourseStudents(Int32.Parse(cc["courseId"].ToString()));

                // does current room have enough seats
                _criteria[ci + 1] = roomSeats >= classSeats;
                // Hard constraint when satisfied nothing happens nothing happens
                //if (_criteria[ci + 1])
                //    score++;
                if (!_criteria[ci + 1])
                    score -= 16;
                // does current room have computers if they are required
                Boolean roomLab = Convert.ToBoolean(rooms.Rows[room]["lab"].ToString().ToLower());
                Boolean classLab = Boolean.Parse(cc["lab"].ToString());
                _criteria[ci + 2] = classLab || (classLab && roomLab);
                // Hard constraint when satisfied nothing happens nothing happens
                //if (_criteria[ci + 2])
                //    score++;
                if (_criteria[ci + 2])
                    score -= 16;
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
                        //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
                        if (cl != null)
                        {
                            foreach (DataRow row in cl)
                            {
                                //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
                                if (cc != row)
                                {
                                    // professor overlaps?
                                    //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
                                    if (cc["instructorId"] == row["instructorId"])
                                    {
                                        po = true;
                                    }

                                    // student group overlaps?
                                    //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:

                                    DataTable curClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(cc["courseId"].ToString()));
                                    DataTable sameTimeClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(row["courseId"].ToString()));

                                    if (!go && curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()) != null)
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
                        score -= 16;
                    _criteria[ci + 3] = !po;

                    // student groups has no overlaping classes?
                    // Hard constraint when satisfied nothing happens nothing happens
                    //if (!go)
                    //    score++;
                    if (go)
                        score -= 16;
                    _criteria[ci + 4] = !go;
                }
                // instructors preferred time
                DataTable dt = counts.GetInstructorPreferredTime(Int32.Parse(cc["instructorId"].ToString()));
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
                bool monorev = false;
                if (Boolean.Parse(cc["lab"].ToString()))
                {
                    if (time >= 12)
                        monorev = true;
                }
                else
                {
                    if (time < 12)
                        monorev = true;
                }
                if (monorev) score++;
                _criteria[ci + 7] = monorev;
                //To know the max hours per day and if a specific group have a day off
                // they must be grouped, insert the data in arrays
                int h;
                if (cc["lab"].ToString() == null)
                    h = 1;
                else h = 2;
                DataTable yd = counts.GetClassYandD(Int32.Parse(cc["courseId"].ToString()));
                foreach (DataRow row in yd.Rows)
                {
                    if (Int32.Parse(row["year"].ToString()) == 1)
                    {
                        if (row["Devision"].ToString().ToLower() == "cs")
                            fcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "math")
                            fm[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "mathcs")
                            fmcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "stat")
                            fs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "statcs")
                            fscs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "it")
                            fit[day, time] = h;
                    }
                    if (Int32.Parse(row["year"].ToString()) == 2)
                    {
                        if (row["Devision"].ToString().ToLower() == "cs")
                            scs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "math")
                            sm[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "mathcs")
                            smcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "stat")
                            ss[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "statcs")
                            sscs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "it")
                            sit[day, time] = h;
                    }
                    if (Int32.Parse(row["year"].ToString()) == 3)
                    {
                        if (row["Devision"].ToString().ToLower() == "cs")
                            tcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "math")
                            tm[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "mathcs")
                            tmcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "stat")
                            ts[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "statcs")
                            tscs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "it")
                            tit[day, time] = h;
                    }
                    if (Int32.Parse(row["year"].ToString()) == 4)
                    {
                        if (row["Devision"].ToString().ToLower() == "cs")
                            focs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "math")
                            fom[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "mathcs")
                            fomcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "stat")
                            fos[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "statcs")
                            foscs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "it")
                            foit[day, time] = h;
                    }
                    if (Int32.Parse(row["year"].ToString()) == 5)
                    {
                        if (row["Devision"].ToString().ToLower() == "cs")
                            fifcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "math")
                            fifm[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "mathcs")
                            fifmcs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "stat")
                            fifs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "statcs")
                            fifscs[day, time] = h;
                        if (row["Devision"].ToString().ToLower() == "it")
                            fifit[day, time] = h;
                    }
                }

            }

            //then call a function and send it all the years and devisions
            //then for each devision of a year whom don't have an off day
            //or consecutive hours more than 6 increment the score
            List<int[,]> data = new List<int[,]> { fm, fmcs, fs, fit, fcs, sm, smcs, ss, sit, scs, tm, tmcs, ts, tit, tcs, fom, fomcs, fos, foit, focs, fifm, fifmcs, fifs, fifit, fifcs };
            score += CheckPref(data);
            //calculate fitess value based on score
            _fitness = (float)score / (Counts.GetInstance().GetNumberOfCourseClasses() * DefineConstants.DAYS_NUM);
        }
        private int CheckPref(List<int[,]> allData)
        {
            int score = 0;
            foreach (int[,] yd in allData)
            {
                score += CheckSoftPref(yd);
            }
            return score;
        }
        //see if the they have a day off + see the maximum hours they are working in
        private int CheckSoftPref(int[,] yd)
        {
            //work here get the day off preferences for each year

            //work here see if the lab and days on same day or not;
            int score = 0;
            int consectiveHours = 0;
            bool consHours = false;
            bool[] days = new bool[7];
            bool prefDayOff = false;
            bool dayOff = false;
            //calculate the number of lectures and labs in a single day
            int numOfLectures = 0;
            int numOfLabs = 0;
            for (int d = 0; d <= 4; d++)
            {

                for (int t = 0; t <= 4; t++)
                {
                    //1 for lectures
                    if (yd[d, t] == 1)
                    {
                        consectiveHours += 2;
                        days[d] = true;
                        numOfLectures++;
                    }
                    if (yd[d, t] != 0)
                    {
                        consectiveHours += 2;
                        days[d] = true;
                        numOfLabs++;
                    }
                }
                if (consectiveHours >= 6)
                    consHours = true;
                //work if day have both
                if (numOfLectures != 0 && numOfLabs != 0)
                    score++;
            }
            //off day
            if (days.Contains(false))
            {
                dayOff = true;
                //get the indexes of all off days if any 
                var result = Enumerable.Range(0, days.Count()).Where(i => days[i] == false).ToList();
                //check if the off day is the preferred one or not !
                //if(result.Contains(integer index of the preffered day))  prefDayOff=true; ;
            }

            bool[] hoursDays = new bool[] { consHours, dayOff, prefDayOff };
            //consecetive hourse
            if (consHours == true)
                score++;
            //checkForOffDay
            if (dayOff == false)
                score++;
            //check if the day off is the preferred day
            if (prefDayOff == false)
                score++;

            return score;
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

        private static Semaphore @lock;
        public static Algorithm GetInstance()
        {

            @lock = new Semaphore(1, 1);
            // global instance doesn't exist?
            if (_instance == null)
            {
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
            @lock = new Semaphore(1, 1);
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
            @lock = new Semaphore(1, 1);
            // do not run already running algorithm
            if (_state == AlgorithmState.AS_RUNNING)
                return;

            _state = AlgorithmState.AS_RUNNING;

            //@lock.Release();
            @lock.Close();

            if (_observer != null)
            {
                // notify observer that execution of algorithm has changed it state
                _observer.EvolutionStateChanged(_state);
            }

            // clear best chromosome group from previous execution
            ClearBest();

            // initialize new population with chromosomes randomly built using prototype
            int z = 0;
            List<ScheduleGenetic> it = _chromosomes.ToList();
            for (int i = 0; i < it.Count; i++)
            {
                // remove chromosome from previous execution
                if (it[i]!=null)
                {
                    if (!it[i].Equals(null))
                    {
                        it[i] = null;
                    }
                }

                // add new chromosome to population
                it[i] = _prototype.MakeNewFromPrototype();
                z = ++i;
                AddToBest(z);
            }

            _currentGeneration = 0;

            while (true)
            {
                @lock.WaitOne();
                // user has stopped execution?
                if (_state != AlgorithmState.AS_RUNNING)
                {
                    @lock.Release();
                    break;
                }

                ScheduleGenetic best = GetBestChromosome();

                // work algorithm has reached criteria?
                if (best.GetFitness() >= 1.5)
                {
                    Counts counts = new Counts();
                    ScheduleTableAdapter sched = new ScheduleTableAdapter();
                    DataTable rooms = counts.GetLectureRooms();
                    _state = AlgorithmState.AS_CRITERIA_STOPPED;
                    for (Dictionary<DataRow, int>.Enumerator x = best.GetClasses().GetEnumerator(); !it.Equals(best.GetClasses().Last()); x.MoveNext())
                    {
                        // coordinate of time-space slot
                        int nr = Counts.GetInstance().GetNumberOfLectureRooms();
                        int daySize = DefineConstants.DAY_HOURS * nr;
                        int p = x.Current.Value;
                        int day = p / daySize;
                        int time = p % daySize;
                        int room = time / DefineConstants.DAY_HOURS;
                        time = time % DefineConstants.DAY_HOURS;

                        int dur = Int32.Parse(x.Current.Key["duration"].ToString());
                        int classId = Int32.Parse(x.Current.Key["id"].ToString());
                        int roomId = Int32.Parse(rooms.Rows[room]["Id"].ToString());
                        //0 = sunday and so on
                        String d = ((DayOfWeek)day).ToString();
                        time = time + 8;
                        sched.Insert(classId, d, time, roomId);
                    }
                
                @lock.Release();
                break;
            }

            @lock.Release();

            // produce offepsing
            List<ScheduleGenetic> offspring = new List<ScheduleGenetic>();
            offspring.Resize(_replaceByGeneration);
            for (int j = 0; j < _replaceByGeneration; j++)
            {
                // selects parent randomly
                ScheduleGenetic p1 = _chromosomes[RandomNumbers.NextNumber() % _chromosomes.Count];
                ScheduleGenetic p2 = _chromosomes[RandomNumbers.NextNumber() % _chromosomes.Count];

                offspring[j] = p1.Crossover(p2);
                offspring[j].Mutation();
            }

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
    @lock = new Semaphore(1, 1);

    if (_state == AlgorithmState.AS_RUNNING)
    {
        _state = AlgorithmState.AS_USER_STOPED;
    }

    @lock.Release();
}

// Returns pointer to best chromosomes in population

// Returns pointer to best chromosomes in population
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Schedule* GetBestChromosome() const
public ScheduleGenetic GetBestChromosome()
{
    return _chromosomes[_bestChromosomes[0]];
}

// Returns current generation
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline int GetCurrentGeneration() const
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
    if ((_currentBestSize == (int)_bestChromosomes.Count && _chromosomes[_bestChromosomes[_currentBestSize - 1]].GetFitness() >= _chromosomes[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
        return;

    // find place for new chromosome
    int i = _currentBestSize;
    for (; i > 0; i--)
    {
        // group is not full?
        if (i < (int)_bestChromosomes.Count)
        {
            // position of new chromosomes is found?
            if (_chromosomes[_bestChromosomes[i - 1]].GetFitness() > _chromosomes[chromosomeIndex].GetFitness())
                break;

            // move chromosomes to make room for new
            _bestChromosomes[i] = _bestChromosomes[i - 1];
        }
        else
        {
            // group is full remove worst chromosomes in the group
            _bestFlags[_bestChromosomes[i - 1]] = false;
        }
    }

    // store chromosome in best chromosome group
    _bestChromosomes[i] = chromosomeIndex;
    _bestFlags[chromosomeIndex] = true;

    // increase current size if it has not reached the limit yet
    if (_currentBestSize < (int)_bestChromosomes.Count)
    {
        _currentBestSize++;
    }
}

// Returns TRUE if chromosome belongs to best chromosome group
private bool IsInBest(int chromosomeIndex)
{
    return _bestFlags[chromosomeIndex];
}

// Clears best chromosome group
private void ClearBest()
{
    for (int i = (int)_bestFlags.Count - 1; i >= 0; --i)
    {
        _bestFlags[i] = false;
    }

    _currentBestSize = 0;
}

    }

}
