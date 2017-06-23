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
        //private EventWaitHandle _event;
        EventWaitHandle _event;
        //System.IntPtr _event;


        //private System.IntPtr _event;
        // Window which displays schedule
        private ChildView _window;

        // Called when algorithm starts execution
        private void BlockEvent()
        {
            _event.Reset();
            //ResetEvent(_event);
        }

        // Called when algorithm finishes execution
        private void ReleaseEvent()
        {
            _event.Set();
            // SetEvent(_event);
        }


        // Initializes observer
        public ScheduleObserver()
        {
            //this._window = null;
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
            // WaitForSingleObject(_event, INFINITE);
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
            _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 5);
        }

        // Copy constructor

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
                _criteria.Resize(Counts.GetInstance().GetNumberOfCourseClasses() * 5);
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
                restart:
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
                // check for room overlapping of classes
                Console.WriteLine("check for room overlapping of classes");
                Console.WriteLine("");

                bool ro = false;
                for (int i = dur - 1; i >= 0; i--)
                {
                    if (_slots[pos + i] != null && _slots[pos + i].Count > 1)
                    {
                        ro = true;
                        break;
                    }
                }

                // on room overlaping
                if (ro)
                {
                    Console.WriteLine("current room overlapped will restart");
                    goto restart;
                }
                // does current room have enough seats
                Console.WriteLine("Does it have enough seats");

                int roomSeats = Int32.Parse(rooms.Rows[room]["numberofseats"].ToString());
                int classSeats = Counts.GetInstance().GetCourseStudents(Int32.Parse(courseRow["courseId"].ToString()));
                if (roomSeats < classSeats)
                {
                    Console.WriteLine("not enough will retart");
                    goto restart;
                }
                // does current room have computers if they are required
                Console.WriteLine("room" + rooms.Rows[room]["lab"].ToString());
                Console.WriteLine("course" + courseRow["lab"].ToString());
                string r = rooms.Rows[room]["lab"].ToString();
                string tryc = courseRow["lab"].ToString();
                Boolean roomLab = Convert.ToBoolean(r);//(rooms.Rows[room]["lab"].ToString().ToLower());
                Boolean classLab = Boolean.Parse(tryc);//Boolean.Parse(courseRow["lab"].ToString());
                Console.WriteLine("have pcs");

                if (classLab && !roomLab)
                {
                    Console.WriteLine("Requires lab and room doesn't support it");
                    goto restart;
                }
                Console.WriteLine("Check for overlapping classes and professors");

                // check overlapping of classes for professors and student groups
                for (int i = nr, t = day * daySize + time; i > 0; i--, t += DefineConstants.DAY_HOURS)
                {
                    // for each hour of class
                    for (int j = dur - 1; j >= 0; j--)
                    {
                        // check for overlapping with other classes at same time
                        List<DataRow> cl = _slots[t + j];
                        //for (LinkedList<CourseClass>.Enumerator it = cl.GetEnumerator(); it.MoveNext();)
                        if (cl != null)
                        {
                            foreach (DataRow row in cl)
                            {
                                if (courseRow != row)
                                {
                                    // professor overlaps
                                    if (courseRow["instructorId"] == row["instructorId"])
                                        goto restart;

                                    // student group overlaps?
                                    DataTable curClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(courseRow["courseId"].ToString()));
                                    DataTable sameTimeClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(row["courseId"].ToString()));

                                    if (curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()) != null)
                                        goto restart;
                                }
                            }
                        }
                    }
                }

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

        // Calculates fitness value of chromosome
        public void CalculateFitness()
        {
            // chromosome's score
            int score = 0;

            int numberOfRooms = Counts.GetInstance().GetNumberOfRooms();
            int daySize = DefineConstants.DAY_HOURS * numberOfRooms;

            int ci = 0;

            // check criterias and calculate scores for each class in schedule
            //for (Dictionary<DataRow, int>.Enumerator it = _classes.GetEnumerator(); !it.Equals(_classes.Last());  it.MoveNext(), ci += 5)
            //{
            //    // coordinate of time-space slot
            //    int p = it.Current.Value;
            //    int day = p / daySize;
            //    int time = p % daySize;
            //    int room = time / DefineConstants.DAY_HOURS;
            //    time = time % DefineConstants.DAY_HOURS;

            //    int dur = Int32.Parse(it.Current.Key["duration"].ToString()); 

            //    // check for room overlapping of classes
            //    bool ro = false;
            //    for (int i = dur - 1; i >= 0; i--)
            //    {
            //        if (_slots[p + i].Count > 1)
            //        {
            //            ro = true;
            //            break;
            //        }
            //    }

            //    // on room overlaping
            //    if (!ro)
            //    {
            //        score++;
            //    }

            //    _criteria[ci + 0] = !ro;

            //    DataRow cc = it.Current.Key;
            //    Room r = Counts.GetInstance().GetRoomById(room);
            //    // does current room have enough seats
            //    _criteria[ci + 1] = r.GetNumberOfSeats() >= cc.GetNumberOfSeats();
            //    if (_criteria[ci + 1])
            //    {
            //        score++;
            //    }

            //    // does current room have computers if they are required
            //    _criteria[ci + 2] = !cc.IsLabRequired() || (cc.IsLabRequired() && r.IsLab());
            //    if (_criteria[ci + 2])
            //    {
            //        score++;
            //    }

            //    bool po = false;
            //    bool go = false;
            //    // check overlapping of classes for professors and student groups
            //    for (int i = numberOfRooms, t = day * daySize + time; i > 0; i--, t += DefineConstants.DAY_HOURS)
            //    {
            //        // for each hour of class
            //        for (int i = dur - 1; i >= 0; i--)
            //        {
            //            // check for overlapping with other classes at same time
            //            LinkedList<CourseClass> cl = _slots[t + i];
            //            //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
            //            for (LinkedList<CourseClass>.Enumerator it = cl.GetEnumerator(); it != cl.end(); it++)
            //            {
            //                //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
            //                if (cc != it)
            //                {
            //                    // professor overlaps?
            //                    //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
            //                    if (!po && cc.ProfessorOverlaps(*it))
            //                    {
            //                        po = true;
            //                    }

            //                    // student group overlaps?
            //                    //C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
            //                    if (!go && cc.GroupsOverlap(*it))
            //                    {
            //                        go = true;
            //                    }

            //                    // both type of overlapping? no need to check more
            //                    if (po && go)
            //                    {
            //                        goto total_overlap;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    total_overlap:

            //    // professors have no overlaping classes?
            //    if (!po)
            //    {
            //        score++;
            //    }
            //    _criteria[ci + 3] = !po;

            //    // student groups has no overlaping classes?
            //    if (!go)
            //    {
            //        score++;
            //    }
            //    _criteria[ci + 4] = !go;
            //}

            //calculate fitess value based on score
            _fitness = (float)score / (Counts.GetInstance().GetNumberOfCourseClasses() * DefineConstants.DAYS_NUM);
        }

        // Returns fitness value of chromosome
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: float GetFitness() const
        public float GetFitness()
        {
            return _fitness;
        }

        // Returns reference to table of classes
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline const hash_map<CourseClass*, int>& GetClasses() const
        public Dictionary<DataRow, int> GetClasses()
        {
            return _classes;
        }

        // Returns array of flags of class requiroments satisfaction
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline const ClassicVector<bool>& GetCriteria() const
        public List<bool> GetCriteria()
        {
            return _criteria;
        }

        // Return reference to array of time-space slots
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline const ClassicVector<ClassicLinkedList<CourseClass*>>& GetSlots() const
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


        // Returns reference to global instance of algorithm

        // Pointer to global instance of algorithm

        // Synchronization of creation and destruction of global instance

        // Returns reference to global instance of algorithm
        private static Semaphore @lock;
        public static Algorithm GetInstance()
        {

            @lock = new Semaphore(1, 1);
            // CSingleLock @lock = new CSingleLock(_instanceSect, 1);
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

            @lock.Release();

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
            for(int i =0;i<it.Count;i++)
            {
                // remove chromosome from previous execution
               if(!it[i].Equals(null))
                {
                    it[i] = null;
                }

                // add new chromosome to population
                it[i] = _prototype.MakeNewFromPrototype();
                z = ++i;
                AddToBest(z);
            }

            _currentGeneration = 0;

            while (true)
            {
                // @lock.Lock();
                @lock.WaitOne();
                // user has stopped execution?
                if (_state != AlgorithmState.AS_RUNNING)
                {
                    //@lock.Unlock();
                    @lock.Release();
                    break;
                }

                ScheduleGenetic best = GetBestChromosome();

                // algorithm has reached criteria?
                if (best.GetFitness() >= 1)
                {
                    _state = AlgorithmState.AS_CRITERIA_STOPPED;
                    //@lock.Unlock();
                    @lock.Release();
                    break;
                }

                //@lock.Unlock();
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
            // CSingleLock @lock = new CSingleLock(_stateSect, 1);
            @lock = new Semaphore(1, 1);

            if (_state == AlgorithmState.AS_RUNNING)
            {
                _state = AlgorithmState.AS_USER_STOPED;
            }

            //@lock.Unlock();
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

        // Returns pointe to algorithm's observer
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline ScheduleObserver* GetObserver() const
        public ScheduleObserver GetObserver()
        {
            return _observer;
        }


        // Tries to add chromosomes in best chromosome group

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

        // Returns TRUE if chromosome belongs to best chromosome group
        private bool IsInBest(int chromosomeIndex)
        {
            return _bestFlags[chromosomeIndex];
        }

        // Clears best chromosome group

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
