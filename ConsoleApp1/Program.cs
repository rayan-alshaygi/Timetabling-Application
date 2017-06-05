using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new MainForm());
            //int numrooms;
            //Console.WriteLine("Enter room numbers");
            //string x=Console.ReadLine();
            //numrooms = Convert.ToInt32(x);
            //var rooms = new List<Room>(numrooms);

            //for (int i = 0; i < numrooms;i++)
            //{
            //    int z = i;
            //    z++;
            //    Console.WriteLine("Enter room "+ z + " name");
            //    string name = Console.ReadLine();
            //    Console.WriteLine("Enter room " + z + " capicity");
            //    int capicity = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Does room " + z + " have lab equipements\nY for yes, N for now\n");
            //    string l=Console.ReadLine();
            //    bool lab;
            //    if (l.ToLower().Equals('y'))
            //        lab = true;
            //    else lab = false;
            //    rooms.Add(new Room(name,lab,capicity));
            //}


        }
    }
}
