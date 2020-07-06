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
    public partial class Personal_Information : Form
    {
        public Personal_Information()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Personal_Information_Load(object sender, EventArgs e)
        {
            textBox1.Text = Globaldate.ID;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
            th.Start();
            this.Close();
        }
        //修改自己的个人信息
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
