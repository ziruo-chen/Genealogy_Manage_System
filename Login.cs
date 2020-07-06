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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
       

        private void Login_Load(object sender, EventArgs e)
        {
            //设置密码输入格式*
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //进入注册界面
            Thread th = new Thread(delegate () { new Register().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            

            SqlCommand com = new SqlCommand("Select M_ID R_psw from Member where M_ID='" + username + "'and R_psw='" + pwd + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            int n = da.Fill(ds, "Member");

            if (n != 0)
            {
                MessageBox.Show("登陆成功");
                textBox1.Visible = true;
                textBox2.Visible = true;
                //保存当前ID

                Globaldate.ID = textBox1.Text.Trim();


                //登陆成功，进入普通用户界面
                Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
                th.Start();
                this.Close();

            }
            else
            {
                MessageBox.Show("输入错误！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("Select M_ID R_psw from Member where M_ID='" + username + "' and R_psw='" + pwd + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            int n = da.Fill(ds, "Member");



            if (n != 0)
            {
               

                MessageBox.Show("登陆成功");
                textBox1.Visible = true;
                textBox2.Visible = true;

                //保存用户登录的ID
                

                //登陆成功，进入管理员界面
                Thread th = new Thread(delegate () { new Administrators().ShowDialog(); });
                th.Start();
                this.Close();

            }
            else
            {
                MessageBox.Show("账号或密码输入错误或者你没有管理员权限！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            con.Close();
        }

       
    }
    

}
