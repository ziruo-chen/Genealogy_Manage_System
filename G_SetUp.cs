using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Genealogy_Management_System
{
    public partial class G_SetUp : Form
    {
        public G_SetUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new Administrators().ShowDialog(); });
            th.Start();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string _Gname = textBox1.Text.Trim();//族谱ID

            string constr = "Server=.;Database=Genealogy Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            

            SqlCommand com2 = new SqlCommand("Select G_ID from Genealogy where G_ID='" + _Gname + "'", con);
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            int n2 = da2.Fill(ds2, "Genealogy");


            if (n2 != 0)
            {
                MessageBox.Show("ID已存在！", "提示");
                textBox1.Text = "";
            }
            else if (textBox1.TextLength > 15)
            {
                MessageBox.Show("ID太长，我怕你记不住，请换个短的吧！", "提示");
                textBox1.Text = "";
            }

            else if (textBox1.Text == "" )
            {
                MessageBox.Show("族谱ID不能为空！", "提示");
            }
            else
            {
                // 指定SQL语句
                string s = "insert into Genealogy(G_ID,G_Name,G_Surname,G_Generationintro,G_Educ,G_Intro) values ('"
                     + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'" +
                     ",'" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                SqlCommand com = new SqlCommand(s, con);
                // 建立SqlDataAdapter和DataSet对象
                int n = com.ExecuteNonQuery();


                com = null;
                com2 = null;

                if (n > 0)
                {
                    MessageBox.Show("添加成功！", "提示");
                }
                else
                    MessageBox.Show("添加失败！", "提示");
                //this.Close();

            }
            con.Close();
        }
    }
}
