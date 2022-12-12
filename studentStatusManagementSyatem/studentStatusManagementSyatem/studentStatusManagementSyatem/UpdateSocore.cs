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
    public partial class UpdateSocore : Form
    {
        public UpdateSocore()
        {
            InitializeComponent();
        }

        private void UpdateSocore_Load(object sender, EventArgs e)
        {
            studentId.Text=BrowseScore.id2[BrowseScore.index];
            courseId.Text = BrowseScore.id1[BrowseScore.index];
            Score.Text = BrowseScore.id3[BrowseScore.index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (studentId.Text == "")
            {
                MessageBox.Show("学号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (courseId.Text == "")
            {
                MessageBox.Show("课程号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (Score.Text == "")
            {
                MessageBox.Show("成绩不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                //判断是否已经录入
                string studentid = studentId.Text;
                string courseid = courseId.Text;
                string score = Score.Text;
                string sql1 = "SELECT COUNT(*) FROM choose WHERE studentId='" + studentid + "' AND courseId='" + courseid + "' ";
                //判断是否存在此学生
                string sql = "SELECT COUNT(*) FROM student WHERE studentId = '" + studentid + "'";
                MySqlCommand com1 = new MySqlCommand(sql, conn);
                // 判断是否存在此课程
                string sql3 = "SELECT COUNT(*) FROM course WHERE courseId = '" + courseid + "'";
                MySqlCommand com2 = new MySqlCommand(sql3, conn);
                MySqlCommand com = new MySqlCommand(sql1, conn);
                if (Convert.ToInt32(com1.ExecuteScalar()) == 0)
                {
                    MessageBox.Show("不存在此学生，请先重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Convert.ToInt32(com2.ExecuteScalar()) == 0)
                {
                    MessageBox.Show("不存在此课程，请先重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//修改
                {
                    string sql2 = "UPDATE choose set studentId='" + studentid + "',courseId='" + courseid + "',grade='" + score + "' where courseId='"+ BrowseScore.id1[BrowseScore.index] + "'and choose.studentId='" + BrowseScore.id2[BrowseScore.index] + "'";
                    MySqlCommand com3 = new MySqlCommand(sql2, conn);
                    com3.ExecuteNonQuery();
                    MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }
    }
}
