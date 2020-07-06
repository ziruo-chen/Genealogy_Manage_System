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
    public partial class Family_Event : Form
    {
        public Family_Event()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void Family_Event_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“genealogy_Management_SystemDataSet2.Event”中。您可以根据需要移动或删除它。
            this.eventTableAdapter.Fill(this.genealogy_Management_SystemDataSet2.Event);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string s;

            //if()
            //判断事件ID是否是本人族谱的
            
            //(select G_ID from Member where M_ID='"+Globaldate.ID+"')
            if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "")
                s = "select * from Event where E_ID='" + textBox1.Text + "' and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "")
                s = "select * from Event where  E_Date='" + textBox2.Text + "'and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "') ";
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
                s = "select * from Event where  E_Name='" + textBox3.Text + "'and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "")
                s = "select * from Event where E_ID='" + textBox1.Text + "'and E_Date='" + textBox2.Text + "' and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "') ";
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "")
                s = "select * from Event where E_ID='" + textBox1.Text + "' and E_Name='" + textBox3.Text + "' and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "")
                s = "select * from Event where E_Date='" + textBox2.Text + "' and E_Name='" + textBox3.Text + "' and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                s = "select * from Event where G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";

            else
                s = "select * from Event where E_ID='" + textBox1.Text + "'and E_Date='" + textBox2.Text + "' and E_Name='" + textBox3.Text + "' and G_ID=(select G_ID from Member where M_ID='" + Globaldate.ID + "')";

            SqlCommand comm = new SqlCommand(s, con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = comm;
            DataSet ds = new DataSet();
            sda.Fill(ds, "Event");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void eventBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
