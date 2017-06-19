using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.TimetableDBDataSetTableAdapters;

namespace ConsoleApp1
{
    class FormDbData
    {
        TimetableDBDataSet timetableDBDS = new TimetableDBDataSet();
        InstructorsTableAdapter insTA = new InstructorsTableAdapter();
        CurriculumTableAdapter curTA = new CurriculumTableAdapter();
        RoomsTableAdapter roomTA = new RoomsTableAdapter();
        CourseClassTableAdapter ccTA = new CourseClassTableAdapter();
        CoursesTableAdapter coursesTA = new CoursesTableAdapter();
        QueriesTableAdapter devQA = new QueriesTableAdapter();
        CurriculumDevisionsTableAdapter cdTA = new CurriculumDevisionsTableAdapter();
        CourseCurriculumsTableAdapter coursecurTA = new CourseCurriculumsTableAdapter();
        CurriculumDevisionsTableAdapter curdvTA = new CurriculumDevisionsTableAdapter();
        CurriculumDevisionsTableAdapter cd = new CurriculumDevisionsTableAdapter();
        ITTableAdapter it = new ITTableAdapter();
        MathCSTableAdapter mc = new MathCSTableAdapter();
        STATTableAdapter s = new STATTableAdapter();
        MathTableAdapter m = new MathTableAdapter();
        STATCSTableAdapter sc = new STATCSTableAdapter();
        CSTableAdapter cs = new CSTableAdapter();

        // create an enum to work with finding null curriculum column
        String[] devisionColumns =new string[6]{"cs","stat","math","mathCS","statCS","IT"};
        public int InsertInstructor(string InstructorName,bool TA)
        {
            int val;
            return val= insTA.Insert(InstructorName,TA);
            
            //return val = Int32.Parse(insTA.InsertInstructor(InstructorName).ToString());
           // return val = ins.InsertInstructor(InstructorName);
        }
        public int getInstructorId(string name)
        {
            DataTable s = insTA.GetId(name);
            return Int32.Parse(s.ToString());
        }
       
        public void insertIntoCourseCurriculums(int courseId,DataTable Ids)
        {
            foreach(DataRow id in Ids.Rows)
            {
                coursecurTA.Insert(courseId,Int32.Parse(id["Id"].ToString()));
            }
            
        }
        public int Curriculmcourse(int coid, string[] dv, int y, int ns)
        {
            String[] divisionColumns = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };

            int id = -1;
            string expression = "";
            for (int i = 0; i <= dv.Count(); i++)
            {
                expression += dv[i] + "=" + y + "and";
                for (int j = 0; j <= 5; j++)
                    if (divisionColumns[j] == dv[i])
                        divisionColumns = divisionColumns.Where(val => val != dv[i]).ToArray();


            }
            for (int k = 0; k <= divisionColumns.Count(); k++)
            {
                if (k != divisionColumns.Count() - 1)
                    expression += divisionColumns[k] + "=null";
            }

            DataTable dt = cdTA.GetData();
            DataRow[] dr = dt.Select(expression);

            id = int.Parse(dr[0].ToString());
            if (id == -1)
            {
                insertCurriculum(coid, y, dv, ns);
            }
            string expression2 = "";
            for (int i = 0; i <= dv.Count(); i++)
            {
                if (i != dv.Count() - 1)
                    expression2 += dv[i] + "=" + y + "and";
                else
                    expression2 += dv[i] + "=" + y;

                DataTable dt2 = cdTA.GetCurriculumIdwithWhere(expression2);
                insertIntoCourseCurriculums(coid, dt2);


            }
            return id;
        }
        public void InsertCourse(string name, int y, string[] dv)
        {
            int ns = 0;
            foreach (string x in dv)
                ns += getDivisionSize(x, y);
            int currentcoid = Int32.Parse(coursesTA.InsertQuery(name, ns).ToString());
            //calls a method that checks if there exists curriculum with this specification
            //and if not create a new one
            int cid = Curriculmcourse(currentcoid, dv, y, ns);

            //then it seraches for all curriculum the have those devisions
            //then inserts them into the courseCurriculum Table
        }
        public void insertRoom(string name, int ns, bool lab)
        {
            roomTA.InsertQuery(name, ns, lab);
        }
        public int getDivisionSize(string dv, int year)
        {
            int size = 0;

            switch (dv.ToLower())
            {
                case "cs":
                    { size = int.Parse(cs.getCSSize(year).ToString()); }
                    break;
                case "math":
                    { size = int.Parse(m.getMathSize(year).ToString()); }
                    break;
                case "mathcs":
                    { size = int.Parse(mc.getMathCSSize(year).ToString()); }
                    break;
                case "it":
                    { size = int.Parse(it.getITSize(year).ToString()); }
                    break;
                case "stat":
                    { size = int.Parse(s.getSTATSize(year).ToString()); }
                    break;
                case "statcs":
                    { size = int.Parse(sc.getStatCSSize(year).ToString()); }
                    break;
            }

            return size;
        }
        public DataTable comboRoom()
        {
            DataTable dt = roomTA.GetData();
            return dt;
        }
        public void insertCurriculum(int coid, int y, string[] dv, int ns)
        {
            //searching for a curriculum that contains all these devisions together
            string s = "";
            string n = "";
            //for serching for all curriculums that the devisions participate in
            string or = "";
            for (int i = 0; i < dv.Count(); i++)
            {
                s += dv[i] + " == "+y;
                or += dv[i] + "=="+y;
                if (i < dv.Count() - 1)
                {
                    s += " && ";
                    or += " && ";

                }
            }
            var dif = devisionColumns.Except(dv);
            int l = dif.Count();
            for (int z = 0; z < l; z++)
            {
                n += "&&" + dif.ElementAt(z) + "==null";
                //if (z != l - 1)
                //    n += "&&";
            }
            int courseCurriculumIds = Int32.Parse(curdvTA.GetCurriculumId1(s, n).ToString());
            // if no such curriuculum exist create a new curriculum 
            // add it in two table curriculum and curriculum dev
            if (courseCurriculumIds.ToString() == null)
            {
                string name = "";
                foreach (string d in dv)
                    name += y + d;
                courseCurriculumIds = courseCurriculumIds = curTA.InsertQuery(name, ns);
                //curdvTA.Insert(courseCurriculumIds,)
            }
            DataTable couCurIds = curdvTA.GetCurriculumIdwithWhere(or);
            DataRow firstId = couCurIds.NewRow();
            firstId["Id"] = courseCurriculumIds;
            couCurIds.Rows.Add(firstId);
            insertIntoCourseCurriculums(coid, couCurIds);
        }
        public void InsertCourse(string name, int y1, string[] dv1, int y2, string[] dv2)
        {
            int ns = 0;
            foreach (string x in dv1)
                ns += ns += getDivisionSize(x, y1);
            foreach (string x in dv2)
                ns += ns += getDivisionSize(x, y2);
            int currentcoid = Int32.Parse(coursesTA.InsertQuery(name, ns).ToString());
            //calls a method that checks if there exists  curriculum with this specification
            //and if not create a new one
            Curriculmcourse(currentcoid, dv1, y1, ns);
            Curriculmcourse(currentcoid, dv2, y2, ns);
            //then it seraches for all curriculum the have those devisions
            //then inserts them into the courseCurriculum Table

        }

        public void insertCurriculum(int coid, int y1, string[] dv1, int y2, string[] dv2, int ns)
        {
            //searching for a curriculum that contains all these devisions together
            string s = "";
            string n = "";
            //for serching for all curriculums that the devisions participate in
            string or = "";
            for (int i = 0; i < dv1.Count(); i++)
            {
                s += dv1[i] + " == "+y1+"&&";
                or += dv1[i] + "=="+y1+"&&";
            }
            for (int i = 0; i < dv2.Count(); i++)
            {
                s += dv2[i] + " == " + y2;
                or += dv2[i] + "==" + y2;
                if (i < dv2.Count() - 1)
                {
                    s += " && ";
                    or += " && ";

                }
            }
            var dif = devisionColumns.Except(dv1.Union(dv2));
            int l = dif.Count();
            for (int z = 0; z < l; z++)
            {
                n += "&&" + dif.ElementAt(z) + "==null";
                //if (z != l - 1)
                //    n += "&&";
            }
            int courseCurriculumIds = Int32.Parse(curdvTA.GetCurriculumId1(s, n).ToString());
            // if no such curriuculum exist create a new curriculum 
            // add it in two table curriculum and curriculum dev
            if (courseCurriculumIds.ToString() == null)
            {
                string name = "";
                foreach (string d in dv1)
                    name += y1 + d;
                foreach (string d in dv2)
                    name += y2 + d;
                courseCurriculumIds = courseCurriculumIds = curTA.InsertQuery(name, ns);
                //curdvTA.Insert(courseCurriculumIds,)
            }
            DataTable couCurIds = curdvTA.GetCurriculumIdwithWhere(or);
            DataRow firstId = couCurIds.NewRow();
            firstId["Id"] = courseCurriculumIds;
            couCurIds.Rows.Add(firstId);
            insertIntoCourseCurriculums(coid, couCurIds);
        }

        public void InsertCourseClass(string name, int duration, bool lab, String Instructor, String Course)
        {
            int instructorId = getInstructorId(Instructor);
            int x = int.Parse(coursesTA.GetId(Course).ToString());
            int ns = int.Parse(coursesTA.GetSize(x).ToString());

            int cid = Int32.Parse(x.ToString());
            ccTA.InsertQuery(name, ns, duration, lab, instructorId, cid);
        }

        public DataTable ComboInstructorName()
        {
            TimetableDBDataSet.InstructorsDataTable i = insTA.GetData();
            //DataTable dt = ins.GetDataName();
            return i;
        }
        public DataTable ComboCourseName()
        {
            //string Query = "Select CourseName from CourseTable where ScheduleRow is null and ScheduleColumn is null";
            //SqlCommand sc = new SqlCommand(Query, ConnectionString.GetConnection());
            DataTable dt = ccTA.GetCoursesNames();
            return dt;
        }
        public DataTable comboDivision()
        {
            DataTable dt = cdTA.GetData();
            return dt;
        }

        public DataTable InstructorName(string CourseName)
        {
            DataTable dt = ccTA.GetClassInstructorName(CourseName);
            return dt;
        }

        public  int insertdivisionsize(string division, int year, int size)
        {
            int val=0;
            switch (division.ToLower())
            {
                case "cs":
                    { val =  cs.InsertCSsize(year, size); }
                    break;
                case "math":
                    { val = Int32.Parse(m.InsertMathsize(year, size).ToString()); }
                    break;
                case "mathcs":
                    { val = Int32.Parse(mc.InsertMath(year, size).ToString()); }
                    break;
                case "it":
                    { val = Int32.Parse(it.InsertIT(year, size).ToString()); }
                    break;
                case "stat":
                    { val = Int32.Parse(s.InsertStat(year, size).ToString()); }
                    break;
                case "statcs":
                    { val = Int32.Parse(sc.InsertStatCS(year, size).ToString()); }
                    break;
            }
            return val;
        }
            //public static DataTable CourseTable()
            //{
            //    string Query = "Select CourseName,InstructorName,ScheduleRow,ScheduleColumn from CourseTable";
            //    SqlCommand sc = new SqlCommand(Query, ConnectionString.GetConnection());
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter sds = new SqlDataAdapter(sc);
            //    sds.Fill(dt);
            //    return dt;
            //}

            //Returns pointer to Instructor with specified ID
            // If there is no Instructor with such ID method returns NULL
            public string GetInstructorNameById(int id)
        {
            DataTable name = insTA.GetDataById(id);
            return name.ToString();
        }

    }
}
