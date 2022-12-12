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
    public partial class sign : Form
    {
        public sign()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (userName.Text == "")
            {
                MessageBox.Show("用户名不能为空", "用户注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (passWord.Text == "")
            {
                MessageBox.Show("密码不能为空", "用户注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if (againPassword.Text == "")
            {
                MessageBox.Show("请再次输入密码", "用户注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }else if (passWord.Text != againPassword.Text)
            {
                MessageBox.Show("两次密码输入不一致", "用户注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string username = userName.Text;
                string password = passWord.Text;
                //账户存入数据库
                string sql = "insert into User set userName='" + username + "',userPassword='" + password + "'";
                MySqlCommand com = new MySqlCommand(sql, conn);
                com.ExecuteNonQuery();
                MessageBox.Show("注册成功", "用户注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
                register stu = new register();
                stu.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register stu = new register();
            stu.Show();
        }
    }
}
