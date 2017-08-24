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
            bool notEmpty;
            int choosenClassId;
            int randomClassId;
            for (int i = 0; i < 10; i++)
            {

                rc = RandomNumbers.NextNumber() % numClasses;
                var listClasses = _classes.Values.ToList();
                randomClassId = Int32.Parse(c.Rows[rc]["Id"].ToString());
                int dur= Int32.Parse(c.Rows[rc]["duration"].ToString());
                do
                {
                    rt = RandomNumbers.NextNumber() % numTimeslots;
                    notEmpty = _classes.ContainsValue(rt);
                    choosenClassId = -1;
                    if (notEmpty)
                    {
                        int classIndexInDict = listClasses.IndexOf(rt);
                        choosenClassId = Int32.Parse(_classes.ElementAt(classIndexInDict).Key["id"].ToString());
                    }
                    //where the slot choosen is npt the one currently used by the class
                } while (!notEmpty);//!notEmpty && choosenClassId != rc || notEmpty);
                DataRow courseRow = c.Rows[rc];
                for (int z = dur - 1; i >= 0; i--)
                {
                    List<DataRow> l = new List<DataRow>();
                    l.Add(courseRow);
                    if (_slots[(rt + i)] == null)
                        _slots[(rt + i)] = l;
                    else
                        _slots[(rt + i)].Add(courseRow);

                }
                _classes.Add(courseRow, rt);
                change.CalculateFitness();
                if (change.GetFitness() > s.GetFitness())
                    s = change;
            }

        }
    }
}

