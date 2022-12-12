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
   
    public partial class BrowseClass : Form
    {
        public static string t1 = "";
        public static string t2 = "";
        public static string t3 = "";
        public static string t4 = "";
        public static string t5 = "";
        public static string t6 = "";
        public static string[] array = new string[100];
        public static int index;
        public BrowseClass()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            string classId = classid.Text;
            string sql = "select * from Class where classId='" + classId + "'";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add("班级编号\t班级名称\t班级人数\t班主任\t  班级说明\t");
            while(reader.Read()){
                listBox1.Items.Add(string.Format("{0}\t{1}\t{2}\t\t{3}\t  {4}", reader[0], reader[1], reader[2], reader[4], reader[3] ));
                
            }
            if (listBox1.Items.Count == 1)
            {
                MessageBox.Show("不存在此班级", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                //先删除这个班的学生
                string sql3 = "DELETE student FROM Student WHERE  Student.classId='" + array[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand comdt = new MySqlCommand(sql3, conn);
                comdt.ExecuteNonQuery();
                //删除
                #region 删除
                string sql = "DELETE FROM Class WHERE ClassId='" + array[listBox1.SelectedIndex-1] + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                #endregion
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Tool.isTeacher==false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            if (listBox1.SelectedIndex>0)
            {
                index = listBox1.SelectedIndex - 1;
                #region 连接数据库
                //定义连接字符串
                string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
                MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
                conn.Open();//打开数据库
                #endregion
                string sql = "select * from Class where classId='" + array[index] + "'";
                MySqlCommand com = new MySqlCommand(sql, conn);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read()){
                    t1 = (string)reader[0];
                    t2 = (string)reader[1];
                    t3 = (string)reader[2];
                    t4 = (string)reader[3];
                    t5 = (string)reader[4];
                    t6 = (string)reader[5];
                }
                
                
                updateClass stu = new updateClass();
                stu.Show();
                this.Hide();
            }
           
        }

        private void BrowseClass_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //获取所有班级

            string sql = "SELECT * FROM Class";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add(string.Format("班级编号\t班级名称\t班级人数\t班主任\t  班级说明\t"));
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0}\t{1}\t{2}\t\t{3}\t  {4}", reader[0], reader[1], reader[2], reader[4], reader[3]));
                array[i++] = (string)reader[0];//将编号依次存入数组
            }
            reader.Close();
        }
    }
}
