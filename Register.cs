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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
            textBox4.UseSystemPasswordChar = true;
            textBox5.PasswordChar = '*';
            textBox5.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //回到登录界面
            Thread th = new Thread(delegate () { new Login().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text.Trim();//用户ID
            string _Fname = textBox3.Text.Trim();//父亲ID
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("select M_ID from Member where M_ID='" + name + "'", con);
            // 建立SqlDataAdapter和DataSet对象
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            int n = da.Fill(ds, "Memebr");

            SqlCommand com1 = new SqlCommand("Select M_ID from Member where M_ID='" + _Fname + "'", con);
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            int n1 = da1.Fill(ds1, "Member");

           

            if (n != 0)
            {
                MessageBox.Show("ID已存在！", "提示");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else if (textBox1.TextLength > 15)
            {
                MessageBox.Show("ID太长，我怕你记不住，请换个短的吧！", "提示");
            }

            else if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("ID或密码不能为空！", "提示");
            }
            else if(n1==0)
            {
                MessageBox.Show("不存在的父亲ID！", "提示");
                //textBox1.Text = "";
                textBox3.Text = "";
            }
            else if(textBox4.Text != textBox4.Text )
            {
                MessageBox.Show("密码不一致！", "提示");
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                // 指定SQL语句
                com = new SqlCommand("insert into Member(M_ID,R_psw,R_Bool,M_FatherID) values ('"
                    + textBox1.Text + "','" + textBox4.Text + "','0','"+textBox3.Text+"')", con);
                // 建立SqlDataAdapter和DataSet对象
                n = com.ExecuteNonQuery();

                if (n > 0)
                {
                    string s = "update Member set G_ID=(select G_ID from Member where M_ID='"+textBox3.Text+"') where M_ID='"
                    + name + "'";
                    com1 = new SqlCommand(s, con);
                    n1=com1.ExecuteNonQuery();

                    if (n1 > 0)
                        MessageBox.Show("注册成功！", "提示");
                    else
                        MessageBox.Show("注册失败！", "提示");
                }
                else
                    MessageBox.Show("注册失败！", "提示");

                com = null;
                com1 = null;
            }
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
