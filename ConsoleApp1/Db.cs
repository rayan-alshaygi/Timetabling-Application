using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Db {
        public static SqlConnection My_Sql_Connection;
        public static SqlConnection GetConnection()
        {
            if (My_Sql_Connection == null)
            {
                My_Sql_Connection = new SqlConnection();
                My_Sql_Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TimetableDB.mdf; Integrated Security=True";
                //My_Sql_Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Mawaat\InProgress\ClassScheduler\ClassScheduler\DBClassScheduler.mdf;Integrated Security=True;User Instance=True";
                My_Sql_Connection.Open();
            }
            return My_Sql_Connection;
        }

        //CountsManager.ConnectionStrings["TimetableDBCS"].ConnectionString;
    }
}
