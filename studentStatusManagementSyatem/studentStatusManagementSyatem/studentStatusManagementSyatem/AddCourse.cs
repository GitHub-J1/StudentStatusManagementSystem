using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace studentStatusManagementSyatem
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = 
                "server=localhost;" +
                "database=studentstatusmanagement;" +
                "uid=root;" +
                "pwd=MySQL0977528;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (courseId.Text == "")
            {
                MessageBox.Show("课程编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if (courseName.Text == "")
            {
                    MessageBox.Show("课程名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if (courseCredit.Text == "")
            {
                MessageBox.Show("课程学分不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //判断课程编号是否已存在
                string courseid = courseId.Text;
                string credit = courseCredit.Text;
                string coursename = courseName.Text;
                string shuoming = textBox1.Text;
                //添加入课程表中
                string sql = "select count(*) from Course where courseId='" + courseid + "'";
                MySqlCommand com = new MySqlCommand(sql, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) > 0)//课程存在
                {
                    MessageBox.Show("此课程已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//添加进数据库
                {
                    string sql2 = "insert into Course set courseID='" + courseid + "',courseGrade='" + credit + "',courseName='" + coursename + "',courseExplain='" + shuoming + "'";
                    MySqlCommand com2 = new MySqlCommand(sql2, conn);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }

            }
        }
    }
}
