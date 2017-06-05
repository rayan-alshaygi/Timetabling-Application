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
        CurriculumTableAdapter cur = new CurriculumTableAdapter();
        RoomsTableAdapter room = new RoomsTableAdapter();
        CourseClassTableAdapter cc = new CourseClassTableAdapter();
        CoursesTableAdapter courses = new CoursesTableAdapter();
    

        // Global instance
        private static Counts _instance = new Counts();

        // Parsed Instructors
        private Dictionary<int, Instructor> _Instructors = new Dictionary<int, Instructor>();

        // Parsed student groups
        private Dictionary<int, Curriculum> _curriculum = new Dictionary<int, Curriculum>();

        // Parsed courses
        private Dictionary<int, Course> _courses = new Dictionary<int, Course>();

        // Parsed rooms
        private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();

        // Parsed classes
        private LinkedList<CourseClass> _courseClasses = new LinkedList<CourseClass>();
        // Returns reference to global instance


        internal Dictionary<string, object> GetDict(DataTable dt)
        {
            Dictionary<String, Object> dic = dt.AsEnumerable().ToDictionary(row => row.Field<String>(0), row => row.Field<Object>(1));
            return dic;
        }
        public static Counts GetInstance()
        {
            return _instance;
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

        // Returns pointer to course with specified ID
        // If there is no course with such ID method returns NULL
        //public Course GetCourseById(int id)
        //{
        //    Dictionary<int, Course*>.iterator it = _courses.find(id);
        //    return it != _courses.end() ? it.second : null;
        //}

        public DataTable GetCourseCurriculums(int id)
        {
            return cc.GetCourseCurriculums(id);
        }
        public int GetNumberOfCourses()
        {
            return (int) cc.Count();
        }

        // Returns pointer to room with specified ID
        // If there is no room with such ID method returns NULL
        //public Room GetRoomById(int id)
        //{
        //    Dictionary<int, Room*>.iterator it = _rooms.find(id);
        //    return it != _rooms.end() ? it.second : null;
        //}

        // Returns number of parsed rooms
        
        public int GetNumberOfRooms() { 
            return (int) room.Count();
        }
        public DataTable GetRooms()
        {
            return room.GetData();
        }
        // Returns reference to list of parsed classes
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline const ClassicLinkedList<CourseClass*>& GetCourseClasses() const
        public DataTable GetCourseClasses()
        {
            DataTable dt = cc.GetData();
            return dt;
            
        }
       

        // Returns number of parsed classes
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline int GetNumberOfCourseClasses() const
        public int GetNumberOfCourseClasses()
        {
            return (int)_courseClasses.Count();
        }




        // Removes blank characters from beginning and end of string
    //    private string TrimString(string str)
    //    {
    //        CharEnumerator it = new CharEnumerator();
    //        for (it = str.GetEnumerator(); it.MoveNext() && char.IsWhiteSpace(it.Current);)
    //        {
    //            ;
    //        }
    //        str = str.Remove(str.GetEnumerator(), it);
    //        //string.reverse_iterator; rit= new string.reverse_iterator();

    //        IEnumerable<int> rit = str;
    //        foreach (var x in enumerableThing.Reverse())
    //            for (rit.Reverse(); rit != str.rend() && char.IsWhiteSpace(*rit); rit++)
    //            {
    //                ;
    //            }
    //        str = str.Remove(str.GetEnumerator() + (str.rend() - rit), str.end());

    //        return str;
    //    }

    }
}
