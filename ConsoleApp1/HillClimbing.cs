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
        public static ScheduleGenetic solve(ScheduleGenetic s)
        {
            int hcIdle = 0;
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
            bool containsValueTS;
            //int randomTSClassId;
            int randomClassId;
            int classIndexInDict;
           // int randomTSClass = -1;
            for (int i = 0; i < 5 && hcIdle<3; i++)
            {     
                hcIdle++;
                Dictionary<int, int> _classesId = _classes.ToDictionary(p => Int32.Parse(p.Key["Id"].ToString()),
                   p => p.Value);
                rc = RandomNumbers.NextNumber() % numClasses;
                var listClasses = _classes.Values.ToList();
                randomClassId = Int32.Parse(c.Rows[rc]["Id"].ToString());
                int dur = Int32.Parse(c.Rows[rc]["duration"].ToString());
                // DataRow please = c.Rows[rc];
                //int x = _classes[please];
                int randomClassOldTS = _classesId[randomClassId];
                classIndexInDict  = listClasses.IndexOf(randomClassOldTS);
                //to limit the number of attempts to find an empty timeslot
                int counter = 0;
                do
                {

                    rt = RandomNumbers.NextNumber() % (numTimeslots-3);
                    containsValueTS = _classes.ContainsValue(rt);
                    //if (containsValueTS)
                    //{
                    //    randomTSClass = listClasses.IndexOf(rt);
                    //    randomTSClassId = Int32.Parse(_classes.ElementAt(randomTSClass).Key["id"].ToString());
                    //}
                    counter++;
                    //continue till the slot choosen is empty or not the one currently used by the class
                } while (counter<4 && containsValueTS);
                if (counter == 4) continue;
                DataRow courseRow = _classes.ElementAt(classIndexInDict).Key;
                Console.WriteLine(_classes[courseRow]);
                for (int z = dur - 1; z >= 0; z--)
                {
                    // add the new timeslot to _slots
                    List<DataRow> l = new List<DataRow>();
                    l.Add(courseRow);
                    if (_slots[(rt + z)] == null)
                        _slots[(rt + z)] = l;
                    else
                        _slots[(rt + z)].Add(courseRow);

                    //remove the old timeslots
                    if (containsValueTS)
                        _slots[(randomClassOldTS + z)].Remove(courseRow);

                }
                _classes[courseRow] = rt;
                change.CalculateFitness();
                if (change.GetFitness() > s.GetFitness())
                {
                    s = change;
                    hcIdle--;
                }
            }
            return s;
        }
    }
}

