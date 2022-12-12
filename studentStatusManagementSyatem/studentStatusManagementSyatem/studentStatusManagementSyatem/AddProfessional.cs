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
    public partial class AddProfessional : Form
    {
       
        public AddProfessional()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (zhuanyeId.Text == "")
            {
                MessageBox.Show("专业编号不能为空不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if (zhuanyeName.Text == "")
            {
                MessageBox.Show("专业名称不能为空不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                //数据库取数据判断专业是否存在
                string zhuanyeid = zhuanyeId.Text;
                string zhuanyename = zhuanyeName.Text;
                string miaoshu = textBox1.Text;
                string sql1 = "select count(*) from major where majorId='"+zhuanyeid+"'";
                MySqlCommand com = new MySqlCommand(sql1, conn);
                if (Convert.ToInt32(com.ExecuteScalar())>0)//专业存在
                {
                    MessageBox.Show("此专业已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//添加进数据库
                {
                    string sql2 = "insert into major set majorId='" + zhuanyeid + "',majorName='" + zhuanyename + "',majorExplain='" + miaoshu + "'";
                    MySqlCommand com2 = new MySqlCommand(sql2, conn);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }

            }
        }

        private void AddProfessional_Load(object sender, EventArgs e)
        {

        }
    }
}
