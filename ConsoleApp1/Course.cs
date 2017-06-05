using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Course
    {
        static int nextId;
        public int _courseId { get; private set; }
        string _name;
        public Course(string n)
        {
            _courseId = Interlocked.Increment(ref nextId);
            _name = n;
        }
        public string GetName()
        {
            return _name;
        }

    }
}
