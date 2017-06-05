using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Instructor
    {
        static int nextId;
        public int _InstructorId { get; private set; }
        string _name;
        // List of classes that Instructor teaches
        private LinkedList<CourseClass> _courseClasses = new LinkedList<CourseClass>();

        public Instructor(string n)
        {
            _InstructorId = Interlocked.Increment(ref nextId);
            _name = n;
        }
        // Bind Instructor to course
        public void AddCourseClass(CourseClass courseClass)
        {
            _courseClasses.AddLast(courseClass);
        }

        // Returns Instructor's name

        public string GetName()
        {
            return _name;
        }

        // Returns reference to list of classes that Instructor teaches

        public LinkedList<CourseClass> GetCourseClasses()
        {
            return _courseClasses;
        }

        // Compares ID's of two objects which represent Instructor

        //public static bool operator == (Instructor ImpliedObject, Instructor rhs)
        //{
        //    return ImpliedObject._InstructorId == rhs._InstructorId;
        //}
        public override bool Equals(object obj)
        {
            return _InstructorId == ((Instructor)obj)._InstructorId;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}



