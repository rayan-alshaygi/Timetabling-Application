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

        public static string StartAnnealing(ScheduleGenetic s)
        {
            ScheduleGenetic change = s;
            //primary configuration of cities
            ScheduleGenetic current = s;
            //the next configuration of cities to be tested
            ScheduleGenetic next = current;
            int iteration = -1;
            //the probability
            double proba;
            double alpha = 0.999;
            double temperature = 400.0;
            double epsilon = 0.001;
            double delta;
            double distance = s.GetFitness();
            Random rnd = new Random();
            //while the temperature did not reach epsilon
            while (temperature > epsilon)
            {
                iteration++;

                //get the next random permutation of distances 
                computeNext(current, next);
                //compute the distance of the new permuted configuration
                delta = next.GetFitness() - distance;
                //if the new distance is better accept it and assign it
                if (delta < 0)
                {
                    current = next;
                    distance = delta + distance;
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
                        distance = delta + distance;
                    }
                }
                //cooling process on every iteration
                temperature *= alpha;
                //print every 400 iterations
                if (iteration % 400 == 0)
                    Console.WriteLine(distance);
            }
            try
            {
                return "best distance is" + distance;
            }
            catch
            {
                return "error";
            }
        }

        /// <summary>
        /// compute a new next configuration
        /// and save the old next as current
        /// </summary>
        /// <param name="c">current configuration</param>
        /// <param name="n">next configuration</param>
        static void computeNext(ScheduleGenetic c, ScheduleGenetic n)
        {
            DataTable classes = Counts.GetInstance().GetCourseClasses();
            int numClasses = classes.Rows.Count;
            // Time-space slots, one entry represent one hour in one classroom
            List<List<DataRow>> _slots = n.GetSlots();
            int numTimeslots = _slots.Count;
            // Used to determine first time-space slot used by class
            Dictionary<DataRow, int> _classes = c.GetClasses();
            int rc;
            int rt;
            rc = RandomNumbers.NextNumber() % numClasses + 1;
            do
            {
                rt = RandomNumbers.NextNumber() % numTimeslots;
                //where the slot choosen is npt the one currently used by the class
            } while (Int32.Parse(_classes.ElementAt(rt).Key["id"].ToString()) != rc);
            n.CalculateFitness();
        }
    }

}
