using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CourseClass
    {
        static int nextId;
        public int CourseClassId { get; private set; }
        private Instructor _instructor;
        // Course to which class belongs
        private Course _course;

        // Student groups who attend class
        private LinkedList<Curriculum> _groups = new LinkedList<Curriculum>();

        // Number of seats (students) required in room
        private int _numberOfSeats;

        // Initicates wheather class requires computers
        private bool _requiresLab;

        // Duration of class in hours
        private int _duration;

        public CourseClass(Instructor ins, Course cou, LinkedList<Curriculum> groups, bool requiresLab, int duration)
        {
            CourseClassId = Interlocked.Increment(ref nextId);

            _instructor = ins;
            _course = cou;
            _numberOfSeats = 0;
            _requiresLab = requiresLab;
            _duration = duration;
            // bind professor to class
            _instructor.AddCourseClass(this);

            // bind student groups to class
            for (LinkedList<Curriculum>.Enumerator it = groups.GetEnumerator(); it.MoveNext();)
            {
                it.Current.AddClass(this);
                _groups.AddLast(it.Current);
                _numberOfSeats += it.Current.GetNumberOfStudents();
            }
        }

        // Frees used memory

        // Frees used memory
        public void Dispose()
        {
        }

        // Returns TRUE if another class has one or overlapping student groups.

        // Returns TRUE if another class has one or overlapping student groups.
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool GroupsOverlap(const CourseClass& c) const
        public bool GroupsOverlap(CourseClass c)
        {
            for (LinkedList<Curriculum>.Enumerator it1 = _groups.GetEnumerator(); it1.MoveNext();)
            {
                for (LinkedList<Curriculum>.Enumerator it2 = c._groups.GetEnumerator(); it2.MoveNext();)
                {
                    if (it1.Current == it2.Current)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool InstructorOverlaps(CourseClass c)
        {
            return _instructor == c._instructor;
        }

        // Return pointer to professor who teaches
        public Instructor GetInstructor()
        {
            return _instructor;
        }

        // Return pointer to course to which class belongs

        public Course GetCourse()
        {
            return _course;
        }

        // Returns reference to list of student groups who attend class

        public LinkedList<Curriculum> GetGroups()
        {
            return _groups;
        }

        // Returns number of seats (students) required in room

        public int GetNumberOfSeats()
        {
            return _numberOfSeats;
        }

        // Returns TRUE if class requires computers in room.

        public bool IsLabRequired()
        {
            return _requiresLab;
        }

        // Returns duration of class in hours

        public int GetDuration()
        {
            return _duration;
        }

    }
}
