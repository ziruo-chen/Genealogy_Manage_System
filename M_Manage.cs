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
    public partial class M_Manage : Form
    {
        public M_Manage()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Administrators().ShowDialog(); });
            th.Start();
            this.Close();
        }

        //修改
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();//成员ID
            string _Fname = textBox3.Text.Trim();//族谱ID
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string sql;

            SqlCommand com1 = new SqlCommand("Select G_ID from Genealogy where G_ID='" + _Fname + "'", con);
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            int n1 = da1.Fill(ds1, "Genealogy");



            if (n1 > 0)
            {
                sql = "update Member set M_Name='" + textBox2.Text + "',G_ID='" + textBox3.Text + "',M_FatherID='" + textBox4.Text + "',M_MotherID='" + textBox6.Text + "',M_Sex='" + textBox8.Text + "',M_Birth='"+textBox9.Text+ "',M_Generation='" + textBox10.Text + "',M_Ranking='" + textBox11.Text + "',M_Birthplace='" + textBox12.Text + "',M_Liveplace='" + textBox13.Text + "'where M_ID='" + textBox1.Text + "'";

                com1 = new SqlCommand(sql, con);

                try
                {
                    com1.ExecuteNonQuery();
                    MessageBox.Show("信息修改成功！");
                }
                catch (Exception msg)
                {
                    MessageBox.Show("修改失败！\n出错原因：" + msg.Message);
                }
            }
            else
            {
                MessageBox.Show("族谱ID不存在！", "提示");
                textBox3.Text = "";
            }
            com1 = null;
            con.Close();

        }
        //查询

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();//用户ID
            
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //成员查找
            string sql = "select * from Member where M_ID='" + name + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            //判断成员ID是否存在
            if (!dr.Read())
            {
                MessageBox.Show("不存在该成员");
                textBox1.Text = "";
            }

            else
            {
                
                //显示相应事件信息
                textBox2.Text = dr["M_Name"].ToString();
                textBox3.Text = dr["G_ID"].ToString();
                textBox4.Text = dr["M_FatherID"].ToString();
                textBox6.Text = dr["M_MotherID"].ToString();
                textBox8.Text = dr["M_Sex"].ToString();
                textBox9.Text = dr["M_Birth"].ToString();
                textBox10.Text = dr["M_Generation"].ToString();//字辈
                textBox11.Text = dr["M_Ranking"].ToString();
                textBox12.Text = dr["M_Birthplace"].ToString();
                textBox13.Text = dr["M_Liveplace"].ToString();

                dr.Close();
                sql = "select M_Name from Member where M_ID='"+textBox4.Text+"'";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    textBox5.Text = dr["M_Name"].ToString();
               
                dr.Close();
                //母亲姓名查找
                sql = "select M_Name from Member where M_ID='"+textBox6.Text+"'";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    textBox7.Text = dr["M_Name"].ToString();
            }
            dr.Close();
            con.Close();
        }
    }
}
