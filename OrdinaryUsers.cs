using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data.SqlClient;

namespace Genealogy_Management_System
{
    public partial class OrdinaryUsers : Form
    {
        public OrdinaryUsers()
        {
            InitializeComponent();
        }

        private void OrdinaryUsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Personal_Information().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Genealogy_Information().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new CloseRelatives_Information().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Branch_Information().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Family_Event().ShowDialog(); });
            th.Start();
            this.Close();
        }
    }
}
