using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Genealogy_Management_System
{
    public partial class Branch_Information : Form
    {
        public Branch_Information()
        {
            InitializeComponent();
        }

        private void Branch_Information_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“genealogy_Management_SystemDataSet5.Member”中。您可以根据需要移动或删除它。
            this.memberTableAdapter.Fill(this.genealogy_Management_SystemDataSet5.Member);
           

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
            th.Start();
            this.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //检验成员表里面是否有该成员
            string sql = "select * from Member where M_ID='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show("不存在该成员！", "提示");
                textBox1.Text = "";
            }
            else
            {
               
                //查询父母
                sql = "Select M_ID,M_Name,M_Sex from Member where M_ID=(Select M_FatherID from Member where M_ID ='"+textBox1.Text+ "') or M_ID=(Select M_MotherID from Member where M_ID ='" + textBox1.Text + "')";
                //查询兄弟
                string sql1;
                sql1 = "select * from Member where M_ID=(Select M_ID from Member where M_FatherID=(Select M_FatherID from Member where M_ID ='" + textBox1.Text + "' ))";
                //查询子女
                string sql2;
                sql2 = "select * from Member where M_FatherID='" + textBox1.Text + "'";
                //fumu
                dr.Close();
                cmd = new SqlCommand(sql, con);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, "Member");
                dataGridView3.DataSource = ds.Tables[0];

                //xionhdi 
                cmd = new SqlCommand(sql1, con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "Member");
                dataGridView1.DataSource = ds.Tables[0];
                //zinv
                cmd = new SqlCommand(sql2, con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "Member");
                dataGridView2.DataSource = ds.Tables[0];
            }
            dr.Close();
            con.Close();
        }

       

        
        private void fillByToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.memberTableAdapter.FillBy(this.genealogy_Management_SystemDataSet5.Member);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
