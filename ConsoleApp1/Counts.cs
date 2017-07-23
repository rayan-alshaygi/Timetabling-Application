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

        public int GetCourseStudents(int courseId)   {
          int size= int.Parse(courses.GetSize(courseId).ToString());
            Console.WriteLine(size);
            return size;
        }

        // Returns number of parsed Instructor

        public int GetNumberOfInstructor()
        {
           
            return (int) ins.Count();
        }

        // Returns pointer to student group with specified ID
        // If there is no student group with such ID method returns NULL
        public void GetCurriculumById(int id)
        {
            
        }

        // Returns number of parsed student groups
        
        public int GetNumberOfCurriculums()
        {

            return (int)cur.Count();
        }

        public DataTable GetCourseCurriculums(int id)
        {

            return courseCur.GetCourseCurriculums(id);
        }
        public DataTable GetInstructorPreferredTime(int id)
        {
            return insTime.GetDataById(id);
        }
        public int GetNumberOfCourses()
        {
            return (int) cc.Count();
        }

        public DataTable GetClassYandD(int cid)
        {
            return cc.GetYDByCourseId(cid);
        }
        // Returns pointer to room with specified ID
        // If there is no room with such ID method returns NULL
        public DataRow GetRoomById(int id)
        {
            DataTable dt=room.GetDataById(id);
            if (dt.Rows.Count!=0)
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

        // Returns number of parsed rooms

        public int GetNumberOfRooms() { 
            return (int) room.Count();
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
       

        // Returns number of parsed classes
    
        public int GetNumberOfCourseClasses()
        {
            return (int) cc.Count();
        }

    }
}
