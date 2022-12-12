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
    public partial class register : Form//登录界面（忘了改文件名了，将错就错叫form1了）
    {
        public register()
        {
            InitializeComponent();
        }
        
         
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            sign stu = new sign();
            stu.Show();
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
            try
            {
                conn.Open();//打开数据库
            }
            catch(Exception ex)
            {
                MessageBox.Show("打开数据库失败\n"+ex.Message);
            }

            #endregion
            if (userName.Text == "")
            {
                MessageBox.Show("用户名不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (passWord.Text == "")
            {
                MessageBox.Show("密码不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text == "")
            {
                MessageBox.Show("验证码不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verification.Text != label4.Text)
            {
                MessageBox.Show("验证码错误，请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //查询数据库账户信息
                string username = userName.Text;
                string password = passWord.Text;
                string sql = "SELECT COUNT(*) FROM USER WHERE userName='" + username + "' AND userPassword = '" + password + "' AND userType = 'teacher';";
                MySqlCommand com = new MySqlCommand(sql, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) == 0)
                {
                    sql = "SELECT COUNT(*) FROM USER WHERE userName='" + username + "' AND userPassword = '" + password + "' AND userType = 'student';";
                    com = new MySqlCommand(sql, conn);
                    if (Convert.ToInt32(com.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("用户名或者密码错误，请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Tool.isTeacher = false;
                        MessageBox.Show("Welcome,student");
                        Menu stu = new Menu();
                        stu.Show();
                        this.Hide();
                    }
                }
                else
                {
                    Tool.isTeacher = true;
                    MessageBox.Show("Welcome,teacher");
                    Menu stu = new Menu();
                    stu.Show();
                    this.Hide();
                }
            }
        }

        private void register_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            label4.Text = Convert.ToString(rd.Next(1000, 10000));
        }

        private void register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
