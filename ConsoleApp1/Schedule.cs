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

        private List<List<DataRow>> _slots = new List<List<DataRow>>();
        List<LinkedList<String>> str = new List<LinkedList<string>>();
        // Class table for chromosome
        // Used to determine first time-space slot used by class
        private Dictionary<CourseClass, int> _classes = new Dictionary<CourseClass, int>();
        public Schedule()
        {
            str.Resize(10);
            _slots.Resize(DefineConstants.DAYS_NUM * DefineConstants.DAY_HOURS * Counts.GetInstance().GetNumberOfRooms());
        }
        public string Algorithm()
        {
            // number of time-space slots
            int size = _slots.Count;
            DataTable rooms = counts.GetLectureRooms();
            DataTable labs = counts.GetLabRooms();

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
                if (Boolean.Parse(courseRow["lab"].ToString() )== false)
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
                int classSeats = counts.GetCourseStudents(Int32.Parse(courseRow["courseId"].ToString()));
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
                        if (cl!=null) {
                            foreach (DataRow row in cl)
                            {
                                if (courseRow != row)
                                {
                                    // professor overlaps
                                    if (courseRow["instructorId"] == row["instructorId"])
                                        goto restart;

                                    // student group overlaps?
                                    DataTable curClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(courseRow["courseId"].ToString()));
                                    DataTable sameTimeClassCurriculums = counts.GetCourseCurriculums(Int32.Parse(row["courseId"].ToString()));

                                    if (curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()) != null)
                                        goto restart;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("trying to see what does the the linked list have as default value\n" + str[2]);
                Console.WriteLine();
                // fill time-space slots, for each hour of class
                List<DataRow> l = new List<DataRow>();
                for (int i = dur - 1; i >= 0; i--)
                {
                    l.Add(courseRow);
                    _slots.Insert((pos + i), l);

                }
                //insert it into the schedule class
                int classId = Int32.Parse(courseRow["id"].ToString());
                int roomId = Int32.Parse(rooms.Rows[room]["Id"].ToString());
                //0 = sunday and so on
                String d = ((DayOfWeek)day).ToString();
                time = time + 8;
                sched.Insert(classId, d, time, roomId);
            }

            return "done";
        }

        public Dictionary<CourseClass, int> GetClasses()
        {
            return _classes;
        }
        public List<List<DataRow>> GetSlots()
        {
            return _slots;
        }


    }
}
