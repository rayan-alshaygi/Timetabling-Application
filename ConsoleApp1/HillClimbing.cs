using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HillClimbing
    {
        public static void solve(ScheduleGenetic s)
        {
            ScheduleGenetic change = s;
            DataTable c = Counts.GetInstance().GetCourseClasses();
            int numClasses = c.Rows.Count;
            // Time-space slots, one entry represent one hour in one classroom
            List<List<DataRow>> _slots = change.GetSlots();
            // Used to determine first time-space slot used by class
            Dictionary<DataRow, int> _classes = change.GetClasses();
            // Fitness value of chromosome
            int numTimeslots = _slots.Count;
            int rc;
            int rt;
            bool Empty;
            int choosenClassId;
            int randomClassId;
            for (int i = 0; i < 200; i++)
            {

                rc = RandomNumbers.NextNumber() % numClasses + 1;
                randomClassId = Int32.Parse(c.Rows[rc]["Id"].ToString());
                do
                {
                    rt = RandomNumbers.NextNumber() % numTimeslots;
                    Empty = _classes.Equals(null);
                    choosenClassId = Int32.Parse(_classes.ElementAt(rt).Key["id"].ToString());
                    //where the slot choosen is npt the one currently used by the class
                } while (!Empty  && choosenClassId != rc);
                change.CalculateFitness();
                if (change.GetFitness() > s.GetFitness())
                    s = change;
            }

        }
    }
}

