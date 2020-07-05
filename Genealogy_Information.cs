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
            /*string B = Form1.A;//本界面B等于A，B是成员编号
            string connStr = @"Server=.; Initial Catalog=shuju; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = @"SELECT * FROM xinxi WHERE [Sno]='" + B + "'";//根据B在数据库里面查找信息
            string sql1 = @"SELECT * FROM xinxi WHERE [Sno]='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();//关于数据库连接部分需要修改代码
            /*
            if (!dr.Read())
            {
                MessageBox.Show("不存在该成员！");
                return;
            }//成员一定存在
            
            textBox1.Text = dr["SurnameG_ID"].ToString();//textbox1是家族姓氏
            textBox2.Text = dr["G_Name"].ToString();//家谱名称
            textBox3.Text = dr["G_Educ"].ToString();//家训
            textBox4.Text = dr["G_GenerationIntro"].ToString();//字辈说明
            textBox5.Text = dr["G_Intro"].ToString();//家谱简介
            conn.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate () { new OrdinaryUsers().ShowDialog(); });
            th.Start();
            this.Close();
        }
    }
}
