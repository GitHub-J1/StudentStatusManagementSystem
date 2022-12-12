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
    public partial class UpdateCourse : Form
    {
        public UpdateCourse()
        {
            InitializeComponent();
        }

        private void UpdateCourse_Load(object sender, EventArgs e)
        {
            courseId.Text = BrowseCourse.t1;
            courseCredit.Text = BrowseCourse.t2;
            courseName.Text = BrowseCourse.t3;
            textBox1.Text = BrowseCourse.t4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            string courseid = courseId.Text;
            string credit = courseCredit.Text;
            string coursename = courseName.Text;
            string shuoming = textBox1.Text;
            //添加入课程表中
            string sql2 = "update  Course set courseGrade='" + credit + "',courseName='" + coursename + "',courseExplain='" + shuoming + "' where courseId='"+courseid+"'";
            MySqlCommand com2 = new MySqlCommand(sql2, conn);
            com2.ExecuteNonQuery();
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
             this.Hide();
        }
    }
}
