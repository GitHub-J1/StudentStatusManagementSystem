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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (studentId.Text == "")
            {
                MessageBox.Show("学号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (studentName.Text == "")
            {
                MessageBox.Show("学生姓名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //  判断该学生是否已经存在
                string studentage = age.Text;
              
                //获得班级名称
                string banji = "";
                if (classId.SelectedIndex != -1)
                {
                    banji  = classId.SelectedItem.ToString();
                }
                else
                {
                    classId.SelectedIndex = 0;
                }
                //获得班级id
                string classid = "";
                string sql = "select ClassId from Class where className='" + banji + "'";
                MySqlCommand comt = new MySqlCommand(sql, conn);
                MySqlDataReader reader = comt.ExecuteReader();
                while (reader.Read())
                {
                    classid = (string)reader[0];
                }
                reader.Close();
                string miashu = textBox5.Text;
                string studentid = studentId.Text;
                string studentname = studentName.Text;
                string studentsex = sex.SelectedItem.ToString();
                string sql1 = "select count(*) from Student where studentId='" + studentid + "'";
                MySqlCommand com = new MySqlCommand(sql1, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) > 0)//学生存在
                {
                    MessageBox.Show("此学生已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//添加进数据库
                {
                    string sql2 = "insert into student set studentId='" + studentid + "',studentName='" + studentname + "',sex='" + studentsex + "',age='" + studentage + "',studentExplain='"+ miashu + "',classId='"+classid+"'";
                    MySqlCommand com2 = new MySqlCommand(sql2, conn);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //导入班级进集合
            MySqlCommand st = new MySqlCommand("select className from Class", conn);
            MySqlDataReader reader1 = st.ExecuteReader();
            classId.Items.Clear();
            while (reader1.Read())
            {
                classId.Items.Add((string)reader1[0]);
            }
            reader1.Close();
        }
    }
}
