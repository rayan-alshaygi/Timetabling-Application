using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Curriculum
    {
        static int nextId;
        public int _CurriculumId { get; private set; }
        string _name;
        private LinkedList<CourseClass> _courseClasses = new LinkedList<CourseClass>();
        int _numberOfStudents;

        public Curriculum(string n, int numberOfStudents)
        {
            _CurriculumId = Interlocked.Increment(ref nextId);
            _name = n;
           _numberOfStudents = numberOfStudents;
        }
        public void AddClass(CourseClass courseClass)
        {
            _courseClasses.AddLast(courseClass);
        }

        // Returns student group ID
        public int GetId()
        {
            return _CurriculumId;
        }

        // Returns name of student group
        public string GetName()
        {
            return _name;
        }

        // Returns number of students in group
        public int GetNumberOfStudents()
        {
            return _numberOfStudents;
        }

        // Returns reference to list of classes that group attends
        public LinkedList<CourseClass> GetCourseClasses()
        {
            return _courseClasses;
        }

        // Compares ID's of two objects which represent student groups

        public override bool Equals(object obj)
        {
            return _CurriculumId == ((Curriculum)obj)._CurriculumId;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }

}
