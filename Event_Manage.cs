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
    public partial class Event_Manage : Form
    {
        public Event_Manage()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“genealogy_Management_SystemDataSet1.Event”中。您可以根据需要移动或删除它。
            this.eventTableAdapter.Fill(this.genealogy_Management_SystemDataSet1.Event);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //查询
        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string s;

            if(textBox1.Text!=""&&textBox2.Text==""&&textBox3.Text=="")
                s = "select * from Event where G_ID='"+ textBox1.Text + "'";
            else if(textBox1.Text=="" && textBox2.Text != "" && textBox3.Text == "")
                s = "select * from Event where  E_ID='" + textBox2.Text + "' ";
            else if(textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
                s = "select * from Event where  E_Date='" + textBox3.Text + "'";
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "")
                s = "select * from Event where G_ID='" + textBox1.Text + "'and E_ID='" + textBox2.Text + "' ";
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "")
                s = "select * from Event where G_ID='" + textBox1.Text + "' and E_Date='" + textBox3.Text + "'";
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "")
                s = "select * from Event where E_ID='" + textBox2.Text + "' and E_Date='" + textBox3.Text + "'";
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                s = "select * from Event";

            else
                s = "select * from Event where G_ID='" + textBox1.Text + "'and E_ID='" + textBox2.Text + "' and E_Date='" + textBox3.Text + "'";

            SqlCommand comm = new SqlCommand(s, con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = comm;
            DataSet ds = new DataSet();
            sda.Fill(ds,"Event");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Event_Add().ShowDialog(); });
            th.Start();
            this.Close();
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Event_Change().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Administrators().ShowDialog(); });
            th.Start();
            this.Close();
        }
    }
}
