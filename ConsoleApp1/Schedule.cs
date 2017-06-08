using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.TimetableDBDataSetTableAdapters;

namespace ConsoleApp1
{
    class Schedule
    { 
        ScheduleTableAdapter sched = new ScheduleTableAdapter();
        Counts counts = new Counts();
        // Time-space slots, one entry represent one hour in one classroom
        
        private List<LinkedList<TimetableDBDataSet.CourseClassRow>> _slots = new List<LinkedList<TimetableDBDataSet.CourseClassRow>>();
        // Class table for chromosome
        // Used to determine first time-space slot used by class
        private Dictionary<CourseClass, int> _classes = new Dictionary<CourseClass, int>();
        public Schedule()
        {
            _slots.Resize(DefineConstants.DAYS_NUM * DefineConstants.DAY_HOURS * Counts.GetInstance().GetNumberOfRooms());
        }
        public void Algorithm()
        { 
          
        // in another class
        // number of time-space slots
        int size = (int)_slots.Count;
            DataTable rooms = counts.GetRooms();

            // place classes at random position
            DataTable c = Counts.GetInstance().GetCourseClasses();
           
            int nr = Counts.GetInstance().GetNumberOfRooms();
            //variable needed in searching for instructors and curriculums over lap
            int daySize = DefineConstants.DAY_HOURS * nr;
            Console.WriteLine("before entering");
            foreach (TimetableDBDataSet.CourseClassRow courseRow in c.Rows)
            {
                Console.WriteLine("currently working in course"+courseRow["Id"]);
                // determine random position of class
                int dur = Int32.Parse(courseRow["duration"].ToString());
                restart:
                int day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                int room = RandomNumbers.NextNumber() % nr;
                int time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                int pos = day * nr * DefineConstants.DAY_HOURS + room * DefineConstants.DAY_HOURS + time;
                Console.WriteLine("picked random numbers");
                // check for room overlapping of classes
                Console.WriteLine("check for room overlapping of classes");
                Console.WriteLine("");

                bool ro = false;
                for (int i = dur - 1; i >= 0; i--)
                {
                    if (_slots[pos + i]!=null && _slots[pos + i].Count > 1)
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
                Console.WriteLine("enough seats");

               int roomSeats =Int32.Parse(rooms.Rows[room]["numberofseats"].ToString());
                Console.WriteLine(courseRow["courseId"].ToString());
               int classSeats= counts.GetCourseStudents( Int32.Parse(courseRow["courseId"].ToString()));
                if (roomSeats < classSeats)
                {
                    Console.WriteLine("not enogh retart");
                    goto restart;
                }
                // does current room have computers if they are required
                Console.WriteLine("room"+rooms.Rows[room]["lab"].ToString());
                Console.WriteLine("course"+courseRow["lab"].ToString());
                string r = rooms.Rows[room]["lab"].ToString();
                string tryc = courseRow["lab"].ToString();
                Boolean roomLab = Convert.ToBoolean(r);//(rooms.Rows[room]["lab"].ToString().ToLower());
                Boolean classLab = Boolean.Parse(tryc);//Boolean.Parse(courseRow["lab"].ToString());
                Console.WriteLine("have pcs");

                if (classLab && !roomLab)
                    goto restart;
                Console.WriteLine("overlapping classes and professors");

                // check overlapping of classes for professors and student groups
                for (int i = nr, t = day * daySize + time; i > 0; i--, t += DefineConstants.DAY_HOURS)
                {
                    // for each hour of class
                    for (int j = dur - 1; j >= 0; j--)
                    {
                        // check for overlapping with other classes at same time
                        LinkedList<TimetableDBDataSet.CourseClassRow> cl = _slots[t + j];
                        //for (LinkedList<CourseClass>.Enumerator it = cl.GetEnumerator(); it.MoveNext();)
                        foreach (TimetableDBDataSet.CourseClassRow row in c.Rows)
                        {
                            if (courseRow != row)
                            {
                                // professor overlaps
                                if (courseRow["instructorId"] == row["instructorId"])
                                    goto restart;

                                // student group overlaps?
                              //  if (counts.GetCourseCurriculums(Int32.Parse( courseRow["Id"].ToString())) == counts.GetCourseCurriculums(Int32.Parse(row["Id"].ToString())))
                                //    goto restart;
                            }
                        }
                    }
                }

               
                // fill time-space slots, for each hour of class
                for (int i = dur - 1; i >= 0; i--)
                {
                    _slots[pos + i].AddLast(courseRow);
                    //_slots.at(pos + i).push_back(*it);

                }
                //insert it into the schedule class
                int classId = Int32.Parse(courseRow["id"].ToString());
                int roomId = Int32.Parse(rooms.Rows[room]["Id"].ToString());
                //0 = sunday and so on
                String d = ((DayOfWeek)day).ToString(); ;
                sched.Insert(classId,d, time, roomId);
            }
        }

        public Dictionary<CourseClass, int> GetClasses()
        {
            return _classes;
        }
        public List<LinkedList<TimetableDBDataSet.CourseClassRow>> GetSlots()
        {
            return _slots;
        }


    }
}
