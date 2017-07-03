using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ChildView
    {

        public ChildView()
        {
            this._schedule = null;
            this._running = false;
        }

        public virtual void Dispose()
        {
            if (_schedule != null)
            {
                _schedule = null;
            }
        }


        // private CCriticalSection _sect = new CCriticalSection();
        public static object _sect = new Object();
        //stores the best chromosome so far
        private ScheduleGenetic _schedule;

        private bool _running;
        private static Semaphore @lock;

        public void SetSchedule(ScheduleGenetic schedule)
        {
            //CSingleLock @lock = new CSingleLock(_sect, 1);
            @lock = new Semaphore(1, 1);
            if (_schedule != null)
            {
                _schedule = null;
            }

            _schedule = schedule.MakeCopy(false);

                @lock.Release();

        }

    public void SetNewState(AlgorithmState state)
    {
        _running = state == AlgorithmState.AS_RUNNING;
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
        //	void NewBestChromosome(Schedule newChromosome);

        // Handles event that is raised when state of execution of algorithm is changed
        //	void EvolutionStateChanged(AlgorithmState newState);

        // Sets window which displays schedule
        public void SetWindow(ChildView window)
        {
            _window = window;
        }

    }
}
        // Schedule chromosome
    /*    public class ScheduleGenetic
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
            private List<LinkedList<CourseClass>> _slots = new List<LinkedList<CourseClass>>();

            // Class table for chromosome
            // Used to determine first time-space slot used by class
            private Dictionary<CourseClass, int> _classes = new Dictionary<CourseClass, int>();
            private ScheduleGenetic scheduleGenetic;
            private bool setupOnly;

            public ScheduleGenetic(ScheduleGenetic scheduleGenetic, bool setupOnly)
            {
                this.scheduleGenetic = scheduleGenetic;
                this.setupOnly = setupOnly;
            }


            // Initializes chromosomes with configuration block (setup of chromosome)
            //	Schedule(int numberOfCrossoverPoints, int mutationSize, int crossoverProbability, int mutationProbability);

            // Copy constructor
            //	Schedule(Schedule c, bool setupOnly);

            // Makes copy ot chromosome
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: Schedule* MakeCopy(bool setupOnly) const;
            //	Schedule MakeCopy(bool setupOnly);

            // Makes new chromosome with same setup but with randomly chosen code
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: Schedule* MakeNewFromPrototype() const;
            //	Schedule MakeNewFromPrototype();

            // Performes crossover operation using to chromosomes and returns pointer to offspring
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: Schedule* Crossover(const Schedule& parent2) const;
            //	Schedule Crossover(Schedule parent2);

            // Performs mutation on chromosome
            //	void Mutation();

            // Calculates fitness value of chromosome
            //	void CalculateFitness();

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
           
            // Returns array of flags of class requiroments satisfaction
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: inline const ClassicVector<bool>& GetCriteria() const
            public List<bool> GetCriteria()
            {
                return _criteria;
            }

            internal ScheduleGenetic MakeCopy(bool setupOnly)
            {
                return new ScheduleGenetic(this, setupOnly);
            }

            // Return reference to array of time-space slots
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: inline const ClassicVector<ClassicLinkedList<CourseClass*>>& GetSlots() const


        } }
*/
        // Genetic algorithm
     /*   public class Algorithm
        {


            // Population of chromosomes
            private List<Schedule> _chromosomes = new List<Schedule>();

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
            private Schedule _prototype;

            // Current generation
            private int _currentGeneration;

            // State of execution of algorithm
            private AlgorithmState _state;

            // Synchronization of algorithm's state
            // private CCriticalSection _stateSect = new CCriticalSection();
            public static object _StateSect = new Object();
            // Pointer to global instance of algorithm
            private static Algorithm _instance;

            // Synchronization of creation and destruction of global instance
            //private static CCriticalSection _instanceSect = new CCriticalSection();
            public static object instanceSect = new Object();

            // Returns reference to global instance of algorithm
            //	static Algorithm GetInstance();

            // Frees memory used by gloval instance
            //	static void FreeInstance();

            // Initializes genetic algorithm
            //	Algorithm(int numberOfChromosomes, int replaceByGeneration, int trackBest, Schedule prototype, ScheduleObserver observer);

            // Frees used resources
            //	public void Dispose();

            // Starts and executes algorithm
            //	void Start();

            // Stops execution of algoruthm
            //	void Stop();

            // Returns pointer to best chromosomes in population
            //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
            //ORIGINAL LINE: Schedule* GetBestChromosome() const;
            //	Schedule GetBestChromosome();

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

        }
    */}

