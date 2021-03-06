﻿using System;
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
        //  public static string conString = "Data Source = DESKTOP-BC1VAP6;Initial Catalog=FixingInsert;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string conString = "Data Source=DESKTOP-BC1VAP6;Initial Catalog=timetableDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        TimetableDBDataSet timetableDBDS = new TimetableDBDataSet();
        InstructorsTableAdapter insTA = new InstructorsTableAdapter();
        CurriculumTableAdapter curTA = new CurriculumTableAdapter();
        RoomsTableAdapter roomTA = new RoomsTableAdapter();
        CourseClassTableAdapter ccTA = new CourseClassTableAdapter();
        CoursesTableAdapter coursesTA = new CoursesTableAdapter();
        CoursesYDTableAdapter cYD = new CoursesYDTableAdapter();
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
        CoursecClassInstructorsTableAdapter ccInst = new CoursecClassInstructorsTableAdapter();

        // create an enum to work with finding null curriculum column
        String[] devisionColumns = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };
        public int InsertInstructor(string InstructorName, bool TA)
        {
            int val;
            return val = insTA.Insert(InstructorName, TA);

            //return val = Int32.Parse(insTA.InsertInstructor(InstructorName).ToString());
            // return val = ins.InsertInstructor(InstructorName);
        }
        public int getInstructorId(string name)
        {
            DataTable s = insTA.GetId(name);
            return Int32.Parse(s.Rows[0]["Id"].ToString());
        }

        public void insertIntoCourseCurriculums(int courseId, DataRow[] Ids)
        {
            foreach (DataRow id in Ids)
            {
                coursecurTA.Insert(Int32.Parse(id["curriculumId"].ToString()), courseId);
            }

        }
        public void Curriculmcourse(int coid, string[] dv, int y, int ns, int?[] sendToCurriculum)
        {
            String[] divisionColumns = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };
            String[] divisionColumn = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" }; ;
            // st[] to store values for curriculum devisions columns in case the curriculum does not exist
            String[] insDevs = new String[6];
            //int id = -1;
            // to checks if there exists curriculum with this specification
            string expression = "";
            for (int i = 0; i < dv.Count(); i++)
            {
                if (dv[i] != null)
                {
                    if (expression.Count() > 2)
                        expression += " and ";
                    expression += dv[i] + " = " + y;
                    for (int j = 0; j < divisionColumn.Count(); j++)
                        if (divisionColumn[j] == dv[i])
                            divisionColumn = divisionColumn.Where(val => val != dv[i]).ToArray();
                    switch (dv[i].ToLower())
                    {
                        case "cs":
                            { insDevs[0] = y.ToString(); }
                            break;
                        case "math":
                            { insDevs[1] = y.ToString(); }
                            break;
                        case "mathcs":
                            { insDevs[2] = y.ToString(); }
                            break;
                        case "stat":
                            { insDevs[3] = y.ToString(); }
                            break;
                        case "statcs":
                            { insDevs[4] = y.ToString(); }
                            break;
                        case "it":
                            {
                                insDevs[5] = y.ToString();
                            }
                            break;
                    }
                }


            }
            for (int k = 0; k < divisionColumn.Count(); k++)
            {
                if (expression.Count() > 2)
                    expression += " and ";
                expression += " " + divisionColumn[k] + " IS NULL ";

            }
            DataTable dt = comboDivision();
            DataRow[] dr = dt.Select(expression);

            int x = dr.Count();
            //if no such curriculum exists then create a new one
            int newCurId = -1;
            if (x == 0)
            {
                newCurId = insertCurriculum(sendToCurriculum, coid, y, dv, ns, insDevs);
            }
            //then it seraches for all curriculum the have those devisions
            string expression2 = "";
            // int count = 0;
            for (int i = 0; i < dv.Count(); i++)
            {
                if (dv[i] != null)
                {
                    if (expression2.Count() > 2)
                        expression2 += " or ";
                    expression2 += dv[i] + " = " + y;
                    // count++;
                }
            }
            DataTable d = comboDivision();
            DataRow[] couCurIds = dt.Select(expression2);
            //DataTable couCurIds = cdTA.GetCurriculumIdwithWhere(expression2);
            if (newCurId != -1)
            {
                DataRow firstId = d.NewRow();
                firstId["curriculumId"] = newCurId;
                int index = couCurIds.Count();
                if (index == 0)
                    couCurIds = new DataRow[1];
                else
                {
                    DataRow[] temp = new DataRow[index + 1];
                    couCurIds.CopyTo(temp, 0);
                    couCurIds = temp;
                }
                couCurIds[index] = firstId;
            }
            insertIntoCourseCurriculums(coid, couCurIds);
        }
        public int InsertCourse(string name, string codeArabic, string codeEnglish, int y, string[] dv)
        {
            int ns = 0;
            foreach (string x in dv)
            {
                if (x != null)
                {
                    ns += getSize(x, y);
                }
            }
            int currentcoid = Int32.Parse(coursesTA.InsertQuery(name, ns, codeArabic, codeEnglish).ToString());
            int?[] dev = courseYDprepare(y, dv);
            cYD.Insert(currentcoid, dev[0], dev[1], dev[2], dev[3], dev[4], dev[5]);
            //calls a method that checks if there exists curriculum with this specification
            //and if not create a new one
            //then it seraches for all curriculum the have those devisions
            //then inserts them into the courseCurriculum Table

            Curriculmcourse(currentcoid, dv, y, ns, dev);
            return currentcoid;
        }
        public int?[] courseYDprepare(int y, string[] dv)
        {
            int?[] dev = new int?[6];
            Console.WriteLine(dev[0]);
            foreach (string z in dv)
            {
                if (z == "cs")
                    dev[0] = y;
                if (z == "stat")
                    dev[1] = y;
                if (z == "math")
                    dev[2] = y;
                if (z == "mathCS")
                    dev[3] = y;
                if (z == "statCS")
                    dev[4] = y;
                if (z == "IT")
                    dev[5] = y;
            }
            return dev;
        }
        public int getSize(String dev, int y)
        {
            DataTable ns;
            switch (dev.ToLower())
            {
                case "cs":
                    {
                        ns = cs.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }
                case "math":
                    {
                        ns = m.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }
                case "mathcs":
                    {
                        ns = mc.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }
                case "it":
                    {
                        ns = it.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }
                case "stat":
                    {
                        ns = s.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }

                case "statcs":
                    {
                        ns = sc.GetSize(y);
                        return Int32.Parse(ns.Rows[0]["size"].ToString());
                    }
            }
            return 0;
        }
        public int InsertCourse(string name, string codeArabic, string codeEnglish, int y1, string[] dv1, int y2, string[] dv2)
        {
            int ns = 0;
            foreach (string x in dv1)
                if (x != null)
                    ns += getSize(x, y1); ;

            foreach (string x in dv2)
                if (x != null)
                    ns += getSize(x, y2);
            int currentcoid = Int32.Parse(coursesTA.InsertQuery(name, ns, codeArabic, codeEnglish).ToString());
            int?[] dev = courseYDprepare(y1, dv1, y2, dv2);
            cYD.Insert(currentcoid, dev[0], dev[1], dev[2], dev[3], dev[4], dev[5]);
            //calls a method that checks if there exists  curriculum with this specification
            //and if not create a new one

            //work they should be incoported together
            Curriculmcourse(currentcoid, dv1, y1, dv2, y2, ns);
            //then it seraches for all curriculum the have those devisions
            //then inserts them into the courseCurriculum Table
            return currentcoid;

        }
        public int?[] courseYDprepare(int y1, string[] dv1, int y2, string[] dv2)
        {
            int?[] dev = new int?[6];
            foreach (string z in dv1)
            {
                if (z == "cs")
                    dev[0] = y1;
                if (z == "stat")
                    dev[1] = y1;
                if (z == "math")
                    dev[2] = y1;
                if (z == "mathCS")
                    dev[3] = y1;
                if (z == "statCS")
                    dev[4] = y1;
                if (z == "IT")
                    dev[5] = y1;
            }
            foreach (string z in dv2)
            {
                if (z == "cs")
                    dev[0] = y2;
                if (z == "stat")
                    dev[1] = y2;
                if (z == "math")
                    dev[2] = y2;
                if (z == "mathCS")
                    dev[3] = y2;
                if (z == "statCS")
                    dev[4] = y2;
                if (z == "IT")
                    dev[5] = y2;
            }
            return dev;
        }
        public void Curriculmcourse(int coid, string[] dv1, int y1, string[] dv2, int y2, int ns)
        {
            String[] divisionColumns1 = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };
            String[] divisionColumns2 = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };
            // st[] to store values for curriculum devisions columns in case the curriculum does not exist
            String[] insDevs = new String[6];
            //int id = -1;
            // to checks if there exists curriculum with this specification
            string expression = "";
            for (int i = 0; i < dv1.Count(); i++)
            {
                if (dv1[i] != null)
                {
                    if (expression.Count() > 2)
                        expression += " and ";
                    expression += dv1[i] + " = " + y1;
                    for (int j = 0; j < divisionColumns1.Count(); j++)
                        if (divisionColumns1[j] == dv1[i])
                            divisionColumns1 = divisionColumns1.Where(val => val != dv1[i]).ToArray();
                    switch (dv1[i].ToLower())
                    {
                        case "cs":
                            { insDevs[0] = y1.ToString(); }
                            break;
                        case "math":
                            { insDevs[1] = y1.ToString(); }
                            break;
                        case "mathcs":
                            { insDevs[2] = y1.ToString(); }
                            break;
                        case "stat":
                            { insDevs[3] = y1.ToString(); }
                            break;
                        case "statcs":
                            { insDevs[4] = y1.ToString(); }
                            break;
                        case "it":
                            {
                                insDevs[5] = y1.ToString();
                            }
                            break;
                    }
                }


            }
            for (int i = 0; i < dv2.Count(); i++)
            {
                if (dv2[i] != null)
                {
                    if (expression.Count() > 2)
                        expression += " and ";
                    expression += dv2[i] + " = " + y2;
                    for (int j = 0; j < divisionColumns2.Count(); j++)
                        if (divisionColumns2[j] == dv2[i])
                            divisionColumns2 = divisionColumns2.Where(val => val != dv2[i]).ToArray();
                    switch (dv2[i].ToLower())
                    {
                        case "cs":
                            { insDevs[0] = y2.ToString(); }
                            break;
                        case "math":
                            { insDevs[1] = y2.ToString(); }
                            break;
                        case "mathcs":
                            { insDevs[2] = y2.ToString(); }
                            break;
                        case "stat":
                            { insDevs[3] = y2.ToString(); }
                            break;
                        case "statcs":
                            { insDevs[4] = y2.ToString(); }
                            break;
                        case "it":
                            {
                                insDevs[5] = y2.ToString();
                            }
                            break;
                    }
                }


            }
            var divisionColumns = divisionColumns1.Intersect(divisionColumns2);
            int c = 0;
            foreach (string value in divisionColumns)
            {
                if (expression.Count() > 2)
                    expression += " and ";
                expression += value + " is null ";
                c++;
            }

            DataTable dt = comboDivision();
            DataRow[] dr = dt.Select(expression);

            int x = dr.Count();
            //if no such curriculum exists then create a new one
            int newCurId = -1;
            if (x == 0)
            {
                newCurId = insertCurriculum(coid, y1, dv1, y2, dv2, ns, insDevs);
            }
            //then it seraches for all curriculum the have those devisions
            string expression2 = "";
            int count = 0;
            for (int i = 0; i < dv1.Count(); i++)
            {
                if (dv1[i] != null)
                {
                    if (expression2.Count() > 2)
                        expression2 += " or ";
                    expression2 += dv1[i] + "=" + y1;
                    count++;
                }
            }
            for (int i = 0; i < dv2.Count(); i++)
            {
                if (dv2[i] != null)
                {
                    if (expression2.Count() > 2)
                        expression2 += " or ";
                    expression2 += dv2[i] + "=" + y2;
                    count++;
                }
            }
            DataTable d = comboDivision();
            DataRow[] couCurIds;
            couCurIds = dt.Select(expression2);
            //DataTable couCurIds = cdTA.GetCurriculumIdwithWhere(expression2);
            if (newCurId != -1)
            {
                DataRow firstId = d.NewRow();
                firstId["curriculumId"] = newCurId;
                int index = couCurIds.Count();
                if (index == 0)
                    couCurIds = new DataRow[1];
                else
                {
                    DataRow[] temp = new DataRow[index + 1];
                    couCurIds.CopyTo(temp, 0);
                    couCurIds = temp;
                }
                couCurIds[index] = firstId;
            }
            insertIntoCourseCurriculums(coid, couCurIds);
        }
        public int insertCurriculum(int?[] YD, int coid, int y, string[] dv, int ns, String[] devs)
        {
            int courseCurriculumIds;
            string name = "";
            int z = 0;
            for (int i = 0; i < devs.Count(); i++)
            {
                if (devs[i] != null)
                {
                    name += y + " " + dv[z];
                    z++;
                }
            }

            curTA.InsertQuery(name, ns);
            DataTable dt = curTA.GetId(name, ns);
            courseCurriculumIds = Int32.Parse(dt.Rows[0]["Id"].ToString());
            //var nullableValues = Array.ConvertAll(devs, value => new int?(value));
            //int?[] devisionColumns = Array.ConvertAll(devs, int.Parse);
            int?[] devisionColumns = Array.ConvertAll(devs, value =>
                string.IsNullOrEmpty(value) ? (int?)null : Convert.ToInt32(value));
            // curdvTA.Insert(courseCurriculumIds, devisionColumns[0], devisionColumns[1], devisionColumns[2], devisionColumns[3], devisionColumns[4], devisionColumns[5]);
            curdvTA.Insert(courseCurriculumIds, YD[0], YD[1], YD[2], YD[3], YD[4], YD[5]);
            return courseCurriculumIds;
        }

        public int insertCurriculum(int coid, int y1, string[] dv1, int y2, string[] dv2, int ns, String[] devs)
        {
            String[] divisionColumns = new string[6] { "cs", "stat", "math", "mathCS", "statCS", "IT" };
            int courseCurriculumIds;
            string name = "";
            for (int i = 0; i < devs.Count(); i++)
            {
                if (devs[i] != null)
                    name += devs[i] + divisionColumns[i];
            }

            curTA.InsertQuery(name, ns);
            DataTable dt = curTA.GetId(name, ns);
            courseCurriculumIds = Int32.Parse(dt.Rows[0]["Id"].ToString());
            //var nullableValues = Array.ConvertAll(devs, value => new int?(value));
            //int?[] devisionColumns = Array.ConvertAll(devs, int.Parse);
            int?[] devisionColumns = Array.ConvertAll(devs, value =>
                string.IsNullOrEmpty(value) ? (int?)null : Convert.ToInt32(value));
            curdvTA.Insert(courseCurriculumIds, devisionColumns[0], devisionColumns[1], devisionColumns[2], devisionColumns[3], devisionColumns[4], devisionColumns[5]);
            return courseCurriculumIds;
        }
        public void insertRoom(string name, int ns, bool lab)
        {
            roomTA.Insert(name, ns, lab);
        }
        public DataTable comboRoom()
        {
            DataTable dt = roomTA.GetData();
            return dt;
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
                s += dv1[i] + " == " + y1 + "&&";
                or += dv1[i] + "==" + y1 + "&&";
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
                foreach (string de in dv1)
                    name += y1 + de;
                foreach (string de in dv2)
                    name += y2 + de;
                courseCurriculumIds = curTA.InsertQuery(name, ns);
                //curdvTA.Insert(courseCurriculumIds,)
            }
            DataTable d = cdTA.GetData();
            DataRow[] couCurIds = d.Select(or);
            //DataTable couCurIds = cdTA.GetCurriculumIdwithWhere(expression2);
            if (courseCurriculumIds != -1)
            {
                DataRow first = d.NewRow();
                first["Id"] = courseCurriculumIds;
                int index = couCurIds.Count();
                couCurIds[index] = first;
            }
            insertIntoCourseCurriculums(coid, couCurIds);
        }

        public void InsertCourseClass(string name, int duration, bool lab, bool tut, int[] Instructor, int CourseId)
        {
            //int instructorId = getInstructorId(Instructor);
            int ccid = Int32.Parse(ccTA.InsertQuery(name, duration, lab, CourseId, tut).ToString());
            foreach (int Id in Instructor)
                ccInst.Insert(ccid, Id);
        }
        public int insertLabsOrTutorial(string name, int duration, bool lab, bool tut, int[] instructor, int courseId)
        {
            int courseClassId = Int32.Parse(ccTA.InsertQuery(name, duration, lab, courseId, tut).ToString());
            foreach (int instructorId in instructor)
            {
                ccInst.Insert(courseClassId, instructorId);
            }
            return courseClassId;
        }
        public DataTable GetCourseIdandName(string code)
        {
            return coursesTA.GetCourseNameAndId(code);
        }
        public DataTable combolab()
        {

            DataTable dt = roomTA.GetLabRooms();
            return dt;
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
            // Data Source = DESKTOP - BC1VAP6; Initial Catalog = "Fixing insert"; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from  CurriculumDevisions", con);
            cmd.CommandType = CommandType.Text;
            DataTable d = new DataTable();
            d.Load(cmd.ExecuteReader());
            return d;
            // return cdTA.GetData().CopyToDataTable();
            //DataTable dt = cdTA.GetData();
            //return dt;
        }

        public DataTable InstructorName(string CourseName)
        {
            DataTable dt = ccTA.GetClassInstructorName(CourseName);
            return dt;
        }

        public int insertdivisionsize(string division, int year, int size, int labroom, int groups)
        {
            int val = 0;
            switch (division.ToLower())
            {
                case "cs":
                    { val = cs.Insert(year, size, labroom, groups); }
                    break;
                case "math":
                    { val = Int32.Parse(m.Insert(year, size, labroom, groups).ToString()); }
                    break;
                case "mathcs":
                    { val = Int32.Parse(mc.Insert(year, size, labroom, groups).ToString()); }
                    break;
                case "it":
                    { val = Int32.Parse(it.Insert(year, size, labroom, groups).ToString()); }
                    break;
                case "stat":
                    { val = Int32.Parse(s.Insert(year, size, labroom, groups).ToString()); }
                    break;
                case "statcs":
                    { val = Int32.Parse(sc.Insert(year, size, labroom, groups).ToString()); }
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

        public int sectioning(int roomsize, int ns)
        {
            int numOfGroups = 0;
            int leftOver = 0;
            numOfGroups = ns / roomsize;
            leftOver = ns % roomsize;
            if (leftOver > roomsize / 3) numOfGroups++;
            List<int> a = new List<int>();
            int membersPerGroup = ns / numOfGroups;
            for (int i = 0; i < numOfGroups; i++)
            {

                if (leftOver > 0)
                {
                    a.Add(membersPerGroup + 1);
                    leftOver--;
                }
                else
                {
                    a.Add(membersPerGroup);
                }

            }
            return numOfGroups;
        }
    }
}
