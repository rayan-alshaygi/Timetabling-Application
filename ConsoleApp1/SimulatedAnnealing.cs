using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SimulatedAnnealing
    {

        public static ScheduleGenetic StartAnnealing(ScheduleGenetic s)
        {
            //primary configuration of classes
            ScheduleGenetic current = s;
            //the next configuration of classes to be tested
            ScheduleGenetic next = current;
            int iteration = -1;
            //the probability
            double proba;
            //double alpha = 0.999;
            double alpha = 0.2;
            double temperature = 40.0;
            double epsilon = 0.001;
            double delta;
            double distance = s.GetFitness();
            Random rnd = new Random();
            //while the temperature did not reach epsilon
            while (temperature > epsilon)
            {
                iteration++;
                Console.WriteLine("iteration \t" + iteration);
                //get the next random permutation of distances 
                computeNext(current, next);
                //compute the distance of the new permuted configuration
                if (distance < 0 && next.GetFitness()<0)
                    delta = - distance - next.GetFitness();
                else
                    delta = distance - next.GetFitness();
                //if the new distance is better accept it and assign it
                //if (delta < 0)
                if (next.GetFitness() > distance)
                {
                    current = next;
                    current.CalculateFitness();
                    distance = current.GetFitness();
                    //distance = delta + distance;
                }
                else
                {
                    proba = rnd.Next();
                    //if the new distance is worse accept 
                    //it but with a probability level
                    //if the probability is less than 
                    //E to the power -delta/temperature.
                    //otherwise the old value is kept
                    if (proba < Math.Exp(-delta / temperature))
                    {
                        current = next;
                        current.CalculateFitness();
                        distance = current.GetFitness();
                        //distance = delta + distance;
                    }
                }
                //cooling process on every iteration
                temperature *= alpha;
                //print every 400 iterations
                //if (iteration % 400 == 0)
                //    Console.WriteLine(distance);
            }
            return current;
        }


        /// <summary>
        /// compute a new next configuration
        /// and save the old next as current
        /// </summary>
        /// <param name="c">current configuration</param>
        /// <param name="n">next configuration</param>
        static void computeNext(ScheduleGenetic c, ScheduleGenetic n)
        {
            bool containsValueTS;
            //int randomTSClassId;
            int randomClassId;
            int classIndexInDict;
            DataTable classes = Counts.GetInstance().GetCourseClasses();
            int numClasses = classes.Rows.Count;
            // Time-space slots, one entry represent one hour in one classroom
            List<List<DataRow>> _slots = n.GetSlots();
            int numTimeslots = _slots.Count;
            // Used to determine first time-space slot used by class
            Dictionary<DataRow, int> _classes = c.GetClasses();
            int rc;
            int rt;
            Dictionary<int, int> _classesId = _classes.ToDictionary(p => Int32.Parse(p.Key["Id"].ToString()),
                   p => p.Value);
            rc = RandomNumbers.NextNumber() % numClasses;
            var listClasses = _classes.Values.ToList();
            randomClassId = Int32.Parse(classes.Rows[rc]["Id"].ToString());
            int dur = Int32.Parse(classes.Rows[rc]["duration"].ToString());
            int randomClassOldTS = _classesId[randomClassId];
            classIndexInDict = listClasses.IndexOf(randomClassOldTS);
            int counter = 0;
            do
            {

                rt = RandomNumbers.NextNumber() % (numTimeslots - 3);
                containsValueTS = _classes.ContainsValue(rt);
                counter++;
                //continue till the slot choosen is empty
            } while (counter < 2 && containsValueTS);
            if (containsValueTS)
                return;
            DataRow courseRow = _classes.ElementAt(classIndexInDict).Key;
            //Console.WriteLine(_classes[courseRow]);
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
            n.CalculateFitness();
        }
    }


}