using ConsoleApp1.TimetableDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Evaluate
    {
        ScheduleGenetic eval = new ScheduleGenetic(2, 2, 80, 3);

        //get the current timetables and evaluate
        public void evaluate()
        {

            ScheduleTableAdapter sched = new ScheduleTableAdapter();
            DataTable sem = sched.GetData();
            DataRow classDR;
            Counts counts = new Counts();
            foreach (DataRow r in sem.Rows)
            {
                int nr = Counts.GetInstance().GetNumberOfLectureRooms();
                int daySize = DefineConstants.DAY_HOURS * nr;
                int curClassId = Int32.Parse(r["courseClassId"].ToString());
                classDR = counts.GetClassById(curClassId);
                int dur = Int32.Parse(classDR["duration"].ToString());
                String d = r["day"].ToString();
                int day = 8;
                if (Enum.IsDefined(typeof(DayOfWeek), d))
                {
                    DayOfWeek x = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d, true);
                    day = (int)x;
                }
                int pos = day * daySize;
                int time = pos % daySize;
                // fill time-space slots, for each hour of class
                List<DataRow> l = new List<DataRow>();
                for (int i = dur - 1; i >= 0; i--)
                {
                    l.Add(classDR);
                    if (_slots[(pos + i)] == null)
                        _slots[(pos + i)] = l;
                    else
                        ._slots[(pos + i)].Add(classDR);
                    // newChromosome._slots.Insert((pos + i), l);

                }
                ._classes.Add(classDR, pos);
            }

        }
    }
}
