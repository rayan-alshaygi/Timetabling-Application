using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class GenerateSheet : Form
    {
        public GenerateSheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Algorithm s = Algorithm.GetInstance();
            //textBox2.Text = s.start();
            s.Start();
            s.Stop();
            Algorithm.FreeInstance();
        }
    }
}
