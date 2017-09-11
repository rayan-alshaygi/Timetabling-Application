
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
            List<bool> _criteria = change.GetCriteria();
            DataTable rooms = Counts.GetInstance().GetRooms();
            int numTimeslots = _slots.Count;
            int rc;
            int rt;
            bool containsValueTS = true;
            //int randomTSClassId;
            int randomClassId;
            int classIndexInDict;
            // int randomTSClass = -1;
            for (int i = 0; i < 5 && hcIdle < 3; i++)
            {
                hcIdle++;
                Dictionary<int, int> _classesId = _classes.ToDictionary(p => Int32.Parse(p.Key["Id"].ToString()),
                   p => p.Value);
                newRandomClass:
                rc = RandomNumbers.NextNumber() % numClasses;
                var listClasses = _classes.Values.ToList();
                randomClassId = Int32.Parse(c.Rows[rc]["Id"].ToString());
                int dur = Int32.Parse(c.Rows[rc]["duration"].ToString());
                // DataRow please = c.Rows[rc];
                //int x = _classes[please];
                int randomClassOldTS = _classesId[randomClassId];
                classIndexInDict = listClasses.IndexOf(randomClassOldTS);
                //to limit the number of attempts to find an empty timeslot
                int counter = 0;
                bool[] crit = new bool[5];
                for (int d = 0; d < 5; d++)
                    crit[d] = _criteria[classIndexInDict * 9 + d];
                if (!crit.Contains(false))
                    goto newRandomClass;
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
                        day = RandomNumbers.NextNumber() % DefineConstants.DAYS_NUM;
                        time = RandomNumbers.NextNumber() % (DefineConstants.DAY_HOURS + 1 - dur);
                        if (time % 2 != 0) time -= 1;
                        rt = day * nr * DefineConstants.DAY_HOURS + randroom * DefineConstants.DAY_HOURS + time;
                        counter++;
                        do
                        {
                            if (_slots[rt] == null)
                                break;
                            if (_slots[rt].Count == 0)
                                break;
                            if (rt < _slots.Count - 7)
                            {
                                if (_slots[rt + 4] == null)
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
                                if (_slots[rt - 4] == null)
                                {
                                    if (time - 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                    {
                                        time = time - 4;
                                        rt = rt - 4;
                                        break;
                                    }
                                }
                            }
                            if (rt < _slots.Count - 5)
                            {
                                if (_slots[rt + 2] == null)
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
                                if (_slots[rt - 2] == null)
                                {
                                    if (time - 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                    {
                                        time = time - 2;
                                        rt = rt - 2;
                                        break;
                                    }
                                }
                            }

                        } while (false);
                        goto cont;
                    }

                    if (crit[1] == true)
                    {
                        do
                        {
                            if (pos < _slots.Count - 7)
                            {
                                if (_slots[pos + 4] == null)
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
                                if (_slots[pos - 4] == null)
                                {
                                    if (time - 4 < DefineConstants.DAY_HOURS + 1 - dur)
                                    {
                                        time = time - 4;
                                        rt = pos - 4;
                                        break;
                                    }
                                }
                            }
                            if (pos < _slots.Count - 5)
                            {
                                if (_slots[pos + 2] == null)
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
                                if (_slots[pos - 2] == null)
                                {
                                    if (time - 2 < DefineConstants.DAY_HOURS + 1 - dur)
                                    {
                                        time = time - 2;
                                        rt = pos - 2;
                                        break;
                                    }
                                }
                            }
                        } while (false);
                        goto cont;
                    }


                    cont:
                    containsValueTS = _classes.ContainsValue(rt);
                    counter++;
                    //continue till the slot choosen is empty or not the one currently used by the class
                } while (false);//counter < 2 && containsValueTS);
                DataRow courseRow = _classes.ElementAt(classIndexInDict).Key;
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

