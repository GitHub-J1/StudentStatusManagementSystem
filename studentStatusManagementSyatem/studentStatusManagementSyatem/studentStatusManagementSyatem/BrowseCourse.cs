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
    public partial class BrowseCourse : Form
    {
        public static string t1;
        public static string t2;
        public static string t3;
        public static string t4;
        string[] array = new string[100];
        public BrowseCourse()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BrowseCourse_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //获取所有专业

            string sql = "SELECT * FROM course";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add(string.Format("课程编号       课程学分          课程名称           课程说明"));
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0,5}\t{1,10}\t{2,15}\t{3,10}", reader[0], reader[1], reader[2],reader[3]));
                array[i++] = (string)reader[0];//将编号依次存入数组
            }
            reader.Close();
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
                //删除所有选课记录
                string sql1 = "delete from choose where courseId='" + array[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand comt = new MySqlCommand(sql1, conn);
                comt.ExecuteNonQuery();
                //删除
                #region 删除
                string sql = "DELETE FROM Course WHERE courseId='" + array[listBox1.SelectedIndex - 1] + "'";
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
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion

            if (listBox1.SelectedIndex > 0)
            {
                //查数据
                string sql2 = "select * from Course where courseId='" + array[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand cmdd = new MySqlCommand(sql2, conn);
                MySqlDataReader reader = cmdd.ExecuteReader();
                while (reader.Read())
                {
                    t1 = (string)reader[0];
                    t2 = (string)reader[1];
                    t3 = (string)reader[2];
                    t4 = (string)reader[3];
                }
                reader.Close();
                UpdateCourse stu = new UpdateCourse();
                stu.Show(this);
                this.Hide();
            }
        }
    }
}
