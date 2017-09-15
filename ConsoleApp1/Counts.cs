using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.TimetableDBDataSetTableAdapters;

namespace ConsoleApp1
{
    class Counts
    {
        InstructorsTableAdapter ins = new InstructorsTableAdapter();
        InstructorPreferredTimeTableAdapter insTime = new InstructorPreferredTimeTableAdapter();
        CurriculumTableAdapter cur = new CurriculumTableAdapter();
        RoomsTableAdapter room = new RoomsTableAdapter();
        CourseClassTableAdapter cc = new CourseClassTableAdapter();
        CoursesTableAdapter courses = new CoursesTableAdapter();
        CourseCurriculumsTableAdapter courseCur = new CourseCurriculumsTableAdapter();
        CoursesYDTableAdapter courseYD = new CoursesYDTableAdapter();
        StudentsPreferencesTableAdapter studentsPreferencesTableAdapter = new StudentsPreferencesTableAdapter();

        // Global instance
        private static Counts _instance = new Counts();

        internal Dictionary<string, object> GetDict(DataTable dt)
        {
            Dictionary<String, Object> dic = dt.AsEnumerable().ToDictionary(row => row.Field<String>(0), row => row.Field<Object>(1));
            return dic;
        }
        public static Counts GetInstance()
        {
            return _instance;
        }

        public int GetCourseStudents(int courseId)
        {
            DataTable dt = courses.GetSizeById(courseId);
            return Int32.Parse(dt.Rows[0]["numberOfStudents"].ToString());
        }

        // get soft prefernces
        public DataTable GetStudentsPrefrences(string name)
        {
            return studentsPreferencesTableAdapter.GetPrefrencesByName(name);
        }
        // Returns number of Instructor

        public int GetNumberOfInstructor()
        {

            return (int)ins.Count();
        }
        // Returns number of student groups

        public int GetNumberOfCurriculums()
        {

            return (int)cur.Count();
        }

        public DataTable GetCourseCurriculums(int id)
        {

            return courseCur.GetCourseCurriculums(id);
        }
        public DataTable GetInstructorPreferredTime(int[] ids)
        {
            DataTable toReturn = new DataTable();
            DataTable temp;
            foreach (int id in ids)
            {
                temp = insTime.GetDataById(id);
                toReturn.Merge(temp);
            }
            return toReturn;
        }
        public int GetNumberOfCourses()
        {
            return (int)cc.Count();
        }

        public DataTable GetClassYandD(int cid)
        {
            return courseYD.GetYDById(cid);// .GetYDByCourseId(cid);
        }
        // Returns row of room with specified ID
        // If there is no room with such ID method returns NULL
        public DataRow GetRoomById(int id)
        {
            DataTable dt = room.GetDataById(id);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public DataRow GetClassById(int id)
        {
            DataTable dt = cc.GetClassById(id);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        //return max capicity of a room
        public int GetRoomMaxCapicityById(int id)
        {
            DataTable dt = room.GetDataById(id);
            if (dt.Rows != null)
            {
                return Int32.Parse(dt.Rows[0]["numberofseats"].ToString());
            }
            return 0;
        }

        // Returns number of rooms
        public int GetNumberOfRooms()
        {
            return (int)room.Count();
        }
        public int GetNumberOfLectureRooms()
        {
            return (int)room.CountLectureRooms();
        }
        public int GetNumberOfLabRooms()
        {
            return (int)room.CountLabRooms();
        }
        public DataTable GetLectureRooms()
        {
            return room.GetRooms();
        }
        public DataTable GetRooms()
        {
            return room.GetData();
        }
        public DataTable GetLabRooms()
        {
            return room.GetLabRooms();
        }
        // Returns reference to list of parsed classes
        public DataTable GetCourseClasses()
        {
            DataTable dt = cc.GetData();
            return dt;

        }
        public int[] GetClassInstructor(int classId)
        {
            CoursecClassInstructorsTableAdapter coursecClassInstructorsTableAdapter = new CoursecClassInstructorsTableAdapter();
            DataTable dt = coursecClassInstructorsTableAdapter.GetInstructorId(classId);
            int[] ids = new int[dt.Rows.Count];
            int c = 0;
            foreach (DataRow id in dt.Rows)
            {
                ids[c] = Int32.Parse(id["instructorId"].ToString());
                c++;
            }
            return ids;
        }
        public DataTable getCourseClassesWithNullValues()
        {
            SqlConnection con = new SqlConnection(FormDbData.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from  CourseClass", con);
            cmd.CommandType = CommandType.Text;
            DataTable d = new DataTable();
            d.Load(cmd.ExecuteReader());
            return d;
        }
        public TimetableDBDataSet.CourseClassDataTable HCGetCourseClasses()
        {
            TimetableDBDataSet.CourseClassDataTable c = cc.GetData();
            return c;

        }

        // Returns number of classes

        public int GetNumberOfCourseClasses()
        {
            return (int)cc.Count();
        }

        public int[] GetRoomWithSeats(int numSeats, bool lab)
        {
            DataTable d = room.GetRoomEnoughSeats(numSeats, lab);
            int[] ids = new int[d.Rows.Count];
            int c = 0;
            foreach (DataRow x in d.Rows)
            {
                ids[c] = Int32.Parse(x["Id"].ToString());
                c++;
            }
            return ids;
        }

    }
}
