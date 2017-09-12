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

        public static ScheduleGenetic StartAnnealing(ScheduleGenetic next, ScheduleGenetic current)
        {
            //primary configuration of classes: current
            //the next configuration of classes to be tested: next
            int iteration = -1;
            //the probability
            double proba;
            //double alpha = 0.999;
            double alpha = 0.2;
            double temperature = 40.0;
            double epsilon = 0.001;
            double delta;
            double distance = current.GetFitness();
            Random rnd = new Random();
            //while the temperature did not reach epsilon
            while (temperature > epsilon)
            {
                iteration++;
                Console.WriteLine("iteration \t" + iteration);
                //get the next random permutation of distances 
                computeNext(next);
                //compute the distance of the new permuted configuration
                if (distance < 0 && next.GetFitness() < 0)
                    delta = -distance + next.GetFitness();
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
        static void computeNext(ScheduleGenetic change)
        {
            DataTable c = Counts.GetInstance().GetCourseClasses();
            int numClasses = c.Rows.Count;
            List<bool> _criteria = change.GetCriteria();
            DataTable rooms = Counts.GetInstance().GetRooms();
            int numTimeslots = change._slots.Count;
            int rc;
            int rt;
            bool containsValueTS = true;
            int randomClassId;
            int classIndexInDict;
            DataRow courseRow;
            Dictionary<int, int> _classesId = change._classes.ToDictionary(p => Int32.Parse(p.Key["Id"].ToString()),
               p => p.Value);
            int numberOfNewRandomClases = 0;
            newRandomClass:
            numberOfNewRandomClases++;
            rc = RandomNumbers.NextNumber() % numClasses;
            var attempt = change._classes.ToDictionary(p => Int32.Parse(p.Key["Id"].ToString()));
            var listClasses = change._classes.Keys.ToList();
            randomClassId = Int32.Parse(c.Rows[rc]["Id"].ToString());
            int dur = Int32.Parse(c.Rows[rc]["duration"].ToString());
            // DataRow please = c.Rows[rc];
            //int x = _classes[please];
            int randomClassOldTS = _classesId[randomClassId];
            var real = attempt[randomClassId];
            courseRow = real.Key;
            classIndexInDict = listClasses.IndexOf(courseRow);
            //to limit the number of attempts to find an empty timeslot
            int counter = 0;
            bool[] crit = new bool[5];
            for (int d = 0; d < 5; d++)
                crit[d] = _criteria[classIndexInDict * 9 + d];
            if (!crit.Contains(false))
                if (numberOfNewRandomClases < 5)
                    goto newRandomClass;
                else
                    return;
            int nr = Counts.GetInstance().GetNumberOfRooms();
            int daySize = DefineConstants.DAY_HOURS * nr;
            int pos = randomClassOldTS;
            int day = pos / daySize;
            int time = pos % daySize;
            int room = time / DefineConstants.DAY_HOURS;
            time = time % DefineConstants.DAY_HOURS;
            do
            {
                rt = RandomNumbers.NextNumber() % (numTimeslots - 3);
                if (crit[0] == false || crit[1] == false)
                {

                    //get a room with enough seats
                    int classSeats = Counts.GetInstance().GetCourseStudents(Int32.Parse(c.Rows[rc]["courseId"].ToString()));
                    Boolean classLab = Boolean.Parse(c.Rows[rc]["lab"].ToString());
                    int[] satsisfyingRooms = Counts.GetInstance().GetRoomWithSeats(classSeats, classLab);
                    int roomId = satsisfyingRooms[RandomNumbers.NextNumber() % satsisfyingRooms.Count()];
                    int randroom = rooms.Rows.IndexOf(rooms.Rows.Find(roomId));
                    newTimeSlot:
                    do
                    {

                        day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                        time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                        if (time % 2 != 0) time -= 1;
                        rt = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                        counter++;


                        if (change._slots[rt] == null)
                            break;
                        if (change._slots[rt].Count == 0)
                            break;
                        if (rt < change._slots.Count - 7)
                        {
                            if (change._slots[rt + 4] == null)
                            {
                                if (time + 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time + 4;
                                    rt = rt + 4;
                                    break;
                                }
                            }
                        }
                        if (rt > 4 && time > 4)
                        {
                            if (change._slots[rt - 4] == null)
                            {
                                if (time - 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time - 4;
                                    rt = rt - 4;
                                    break;
                                }
                            }
                        }
                        if (rt < change._slots.Count - 5)
                        {
                            if (change._slots[rt + 2] == null)
                            {
                                if (time + 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time + 2;
                                    rt = rt + 2;
                                    break;
                                }
                            }
                        }
                        if (rt > 2 && time > 2)
                        {
                            if (change._slots[rt - 2] == null)
                            {
                                if (time - 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time - 2;
                                    rt = rt - 2;
                                    break;
                                }
                            }
                        }
                    } while (true);
                    //cc = _classes.ElementAt(classIndexInDict).Key;
                    bool go = false;
                    for (int e = rooms.Rows.Count, t = day * daySize + time; e > 0; e--, t += DefineConstants.DAY_HOURS)
                    {
                        // for each hour of class
                        for (int j = dur - 1; j >= 0; j--)
                        {
                            // check for overlapping with other classes at same time
                            List<DataRow> cl = change._slots[t + j];
                            if (cl != null)
                            {
                                foreach (DataRow crow in cl)
                                {
                                    if (courseRow != crow)
                                    {
                                        // professor overlaps?
                                        if (Counts.GetInstance().GetClassInstructor(Int32.Parse(courseRow["courseId"].ToString())) == Counts.GetInstance().GetClassInstructor(Int32.Parse(crow["courseId"].ToString())))
                                        {
                                            goto newTimeSlot;
                                        }

                                        // student group overlaps?

                                        DataTable curClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(courseRow["courseId"].ToString()));
                                        DataTable sameTimeClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(crow["courseId"].ToString()));
                                        curClassCurriculums.Columns.Remove("courseId");
                                        sameTimeClassCurriculums.Columns.Remove("courseId");
                                        int[] curClassCurriculumsIds = new int[curClassCurriculums.Rows.Count];
                                        int[] sameTimeClassCurriculumsIds = new int[sameTimeClassCurriculums.Rows.Count];
                                        var intersection = curClassCurriculumsIds.Intersect(sameTimeClassCurriculumsIds);
                                        if (!go && curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()).Count() != 0) //intersection.Count() !=0)//
                                        {
                                            goto newTimeSlot;
                                        }

                                    }
                                }
                            }
                        }

                        goto cont;
                    }

                }
                if (crit[1] == true)
                {
                    newTimeSlot:
                    do
                    {
                        if (pos < change._slots.Count - 7)
                        {
                            if (change._slots[pos + 4] == null)
                            {
                                if (time + 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time + 4;
                                    rt = pos + 4;
                                    break;
                                }
                            }
                        }
                        if (pos > 4 && time > 4)
                        {
                            if (change._slots[pos - 4] == null)
                            {
                                if (time - 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time - 4;
                                    rt = pos - 4;
                                    break;
                                }
                            }
                        }
                        if (pos < change._slots.Count - 5)
                        {
                            if (change._slots[pos + 2] == null)
                            {
                                if (time + 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time + 2;
                                    rt = pos + 2;
                                    break;
                                }
                            }
                        }
                        if (pos > 2 && time > 2)
                        {
                            if (change._slots[pos - 2] == null)
                            {
                                if (time - 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                {
                                    time = time - 2;
                                    rt = pos - 2;
                                    break;
                                }
                            }
                        }
                    } while (true);
                    //cc = _classes.ElementAt(classIndexInDict).Key;
                    bool go = false;
                    for (int e = rooms.Rows.Count, t = day * daySize + time; e > 0; e--, t += DefineConstants.DAY_HOURS)
                    {
                        // for each hour of class
                        for (int j = dur - 1; j >= 0; j--)
                        {
                            // check for overlapping with other classes at same time
                            List<DataRow> cl = change._slots[rt + j];
                            if (cl != null)
                            {
                                foreach (DataRow crow in cl)
                                {
                                    if (courseRow != crow)
                                    {
                                        // professor overlaps?
                                        if (Counts.GetInstance().GetClassInstructor(Int32.Parse(courseRow["courseId"].ToString())) == Counts.GetInstance().GetClassInstructor(Int32.Parse(crow["courseId"].ToString())))
                                        {
                                            goto newTimeSlot;
                                        }

                                        // student group overlaps?

                                        DataTable curClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(courseRow["courseId"].ToString()));
                                        DataTable sameTimeClassCurriculums = Counts.GetInstance().GetCourseCurriculums(Int32.Parse(crow["courseId"].ToString()));
                                        curClassCurriculums.Columns.Remove("courseId");
                                        sameTimeClassCurriculums.Columns.Remove("courseId");
                                        int[] curClassCurriculumsIds = new int[curClassCurriculums.Rows.Count];
                                        int[] sameTimeClassCurriculumsIds = new int[sameTimeClassCurriculums.Rows.Count];
                                        //int count = 0;
                                        //foreach (DataRow id in curClassCurriculums.Rows)
                                        //{
                                        //    curClassCurriculumsIds[count] = Int32.Parse(id["curriculumId"].ToString());
                                        //    count++;
                                        //}
                                        //count = 0;
                                        //foreach (DataRow id in sameTimeClassCurriculums.Rows)
                                        //{
                                        //    sameTimeClassCurriculumsIds[count] = Int32.Parse(id["curriculumId"].ToString());
                                        //    count++;
                                        //}
                                        var intersection = curClassCurriculumsIds.Intersect(sameTimeClassCurriculumsIds);
                                        if (!go && curClassCurriculums.AsEnumerable().Intersect(sameTimeClassCurriculums.AsEnumerable()).Count() != 0) //intersection.Count() !=0)//
                                        {
                                            goto newTimeSlot;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    goto cont;
                }


                cont:
                for (int k = dur - 1; k >= 0; k--)//_classes.ContainsValue(rt);
                    if (change._slots[rt + k] == null)
                        containsValueTS = false;
                counter++;
                //continue till the slot choosen is empty or not the one currently used by the class
            } while (containsValueTS);//counter < 2 && containsValueTS);

            for (int z = dur - 1; z >= 0; z--)
            {
                // add the new timeslot to change._slots
                List<DataRow> l = new List<DataRow>();
                l.Add(courseRow);
                if (change._slots[(rt + z)] == null)
                    change._slots[(rt + z)] = l;
                else
                    change._slots[(rt + z)].Add(courseRow);

                //remove the old timeslots
                change._slots[(randomClassOldTS + z)].Remove(courseRow);
            }
            change._classes[courseRow] = rt;
            change.CalculateFitness();
        }

    }
}