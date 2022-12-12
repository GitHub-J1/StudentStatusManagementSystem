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
    public partial class BrowseMajor : Form
    {
        public static string t1;
        public static string t2;
        public static string t3;
        public static string[] array = new string[100];
        public static int index;
        public BrowseMajor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BrowseMajor_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //获取所有专业
            
            string sql = "SELECT * FROM major";
            MySqlCommand com = new MySqlCommand(sql, conn);
            MySqlDataReader reader = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox1.Items.Add(string.Format("专业编号       专业名          专业说明"));
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0,5}\t{1,10}\t{2,10}",reader[0],reader[1],reader[2]));
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
                //删除这个专业的学生
                string sql3 = "DELETE student FROM Student,Class WHERE  Student.classId=Class.classId AND Class.majorId='"+array[listBox1.SelectedIndex - 1]+"'";
                MySqlCommand comdt = new MySqlCommand(sql3, conn);
                comdt.ExecuteNonQuery();
                //先删除在这个专业的所有班级
                string sql1 = "DELETE FROM Class WHERE class.majorId='"+ array[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand comd = new MySqlCommand(sql1, conn);
                comd.ExecuteNonQuery();

                //删除专业
                #region 删除
                string sql = "DELETE FROM major WHERE majorId='" + array[listBox1.SelectedIndex - 1] + "'";
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
                string sql2 = "select * from major where majorId='" + array[listBox1.SelectedIndex - 1] + "'";
                MySqlCommand cmdd = new MySqlCommand(sql2, conn);
                MySqlDataReader reader = cmdd.ExecuteReader();
                while (reader.Read())
                {
                    t1 = (string)reader[0];
                    t2 = (string)reader[1];
                    t3 = (string)reader[2];
                }
                reader.Close();
                BrowseMajor.index = listBox1.SelectedIndex - 1;
                UpdateMajor stu = new UpdateMajor();
                stu.Show(this);
                this.Hide();
                
            }
           
           
            
            
        }
    }
}
