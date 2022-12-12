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
    public partial class BrowseScore : Form
    {
       public static string[] id1 = new string[100];
       public static string[] id2 = new string[100];
        public static string[] id3 = new string[100];
        public static int index;
        public BrowseScore()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string studentid = studentId.Text;
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            string sql = "SELECT course.courseId,student.studentId,studentName,courseName,grade FROM choose,student,course WHERE choose.courseId=course.courseId AND choose.studentId=student.studentId AND student.studentId='"+studentid+"'";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add("课程号\t学号\t\t    姓名\t  课程名\t\t成绩");
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0,5}\t{1,5}\t{2,10}\t{3,10}\t{4,10}", reader[0], reader[1], reader[2], reader[3],reader[4]));
                id1[i] = (string)reader[0];
                id2[i] = (string)reader[1];
                id3[i++] = (string)reader[4];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (listBox1.SelectedIndex > 0)
            {
                //删除
                #region 删除
                string sql = "delete FROM choose WHERE choose.courseId='"+ id1[listBox1.SelectedIndex - 1] + "' AND choose.studentId='"+ id2[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                #endregion
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            if (listBox1.SelectedIndex > 1)
            {
                index = listBox1.SelectedIndex - 1;
                UpdateSocore stu = new UpdateSocore();
                stu.Show(this);
                this.Hide();
            }
            
        }
    }
}
