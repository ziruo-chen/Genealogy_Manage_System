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
    public partial class Genealogy_Information : Form
    {
        public Genealogy_Information()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Genealogy_Information_Load(object sender, EventArgs e)
        {
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string sql = "select * from Genealogy where G_ID=(select G_ID from Member where M_ID='"+Globaldate.ID+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {

            }
            else
            {
                textBox1.Text = dr["G_Surname"].ToString();
                textBox2.Text = dr["G_Name"].ToString();
                textBox3.Text = dr["G_Educ"].ToString();
                textBox4.Text = dr["G_GenerationIntro"].ToString();
                textBox5.Text = dr["G_Intro"].ToString();
            }
           

            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
            th.Start();
            this.Close();
        }
    }
}
