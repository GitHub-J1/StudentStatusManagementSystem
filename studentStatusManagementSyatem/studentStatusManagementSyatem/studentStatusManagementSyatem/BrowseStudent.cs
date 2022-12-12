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
    public partial class BrowseStudent : Form
    {
        public static string t1 = "";
        public static string t2 = "";
        public static string t3 = "";
        public static string t4 = "";
        public static string t5 = "";
        public static string t6 = "";
        public static string[] array = new string[100];
        public BrowseStudent()
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
            string sql = "select * from Student where studentId='" + studentid + "'";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add("  学号\t\t姓名\t性别\t年龄\t 班级编号\t 说明\t");
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2],reader[3],reader[5],reader[4]));
                
            }
            if (listBox1.Items.Count == 1)
            {
                MessageBox.Show("不存在此学生", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            if (listBox1.SelectedIndex>0)
            {
                //删除学生的所有成绩
                string sql1 = "delete from choose where studentId='"+ BrowseStudent.t1 + "'";
                MySqlCommand cmdt = new MySqlCommand(sql1, conn);
                cmdt.ExecuteNonQuery();
                //删除
                #region 删除
                string sql = "DELETE FROM Student WHERE studentId='" + BrowseStudent.t1 + "'";
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
            if (listBox1.SelectedIndex> 0)
            {
                #region 连接数据库
                //定义连接字符串
                string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
                MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
                conn.Open();//打开数据库
                #endregion
                string sql = "select * from Student where studentId='" + array[listBox1.SelectedIndex-1] + "'";
                MySqlCommand com = new MySqlCommand(sql, conn);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    t1 = (string)reader[0];
                    t2 = (string)reader[1];
                    t3 = (string)reader[2];
                    t4 = (string)reader[3];
                    t5 = (string)reader[4];
                    t6 = (string)reader[5];
                }
                
                UpdateStudent stu = new UpdateStudent();
                stu.Show(this);
                this.Hide();
            }
        }

        private void BrowseStudent_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //获取所有班级

            string sql = "SELECT * FROM student";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add(string.Format("  学号\t\t姓名\t性别\t年龄\t 班级编号\t 说明\t"));
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[5], reader[4]));
                array[i++] = (string)reader[0];//将编号依次存入数组
            }
            reader.Close();

        }
    }
    
}
