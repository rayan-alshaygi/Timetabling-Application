using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Room
    {
        static int nextId;
        public int _RoomId { get; private set; }
        string _name;
        int _numberOfSeats;
        // Inidicates if room has computers
        private bool _lab;

        public Room(string n, bool lab, int ns)
        {
            _RoomId= Interlocked.Increment(ref nextId);
            _name = n;
            _numberOfSeats = ns;
            _lab = lab;
        }
        public string GetName()
        {
            return _name;
        }

        // Returns TRUE if room has computers otherwise it returns FALSE

        public bool IsLab()
        {
            return _lab;
        }

        // Returns number of seats in room
        public int GetNumberOfSeats()
        {
            return _numberOfSeats;
        }

  
    }
}
