using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Genealogy_Management_System
{
    public partial class Administrators : Form
    {
        public Administrators()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Event_Manage().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new G_SetUp().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new G_Manage().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new M_Add().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new M_Manage().ShowDialog(); });
            th.Start();
            this.Close();
        }
    }
}
