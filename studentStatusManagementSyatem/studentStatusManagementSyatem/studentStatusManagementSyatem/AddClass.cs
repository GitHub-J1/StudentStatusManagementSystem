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
    public partial class AddClass : Form
    {
        public AddClass()
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
            string connStr = 
                "server=localhost;" +
                "database=studentstatusmanagement;" +
                "uid=root;" +
                "pwd=MySQL0977528;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            if (classId.Text=="")
            {
                MessageBox.Show("班级编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if (className.Text == "")
            {
                MessageBox.Show("班级名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string banjiId = classId.Text;
                string banjiName = className.Text;
                string banzhur = teacher.Text;
                string renshu = count.Text;
                //获得专业名称
                string zhuanye = "";
                if (major.SelectedIndex != -1)
                {
                    zhuanye = major.SelectedItem.ToString();
                }
                else
                {
                    major.SelectedIndex = 0;
                }
                //获得专业id
                string zhuanyeId="";
                string sql = "select majorId from major where majorName='" + zhuanye + "'";
                MySqlCommand comt = new MySqlCommand(sql,conn);
                MySqlDataReader reader = comt.ExecuteReader();
                while (reader.Read())
                {
                    zhuanyeId =(string) reader[0];
                }
                reader.Close();
                MySqlCommand comm = new MySqlCommand();
                string shuoming = emplain.Text;
                string sql1 = "select count(*) from Class where ClassId='" + banjiId + "'";
                MySqlCommand com = new MySqlCommand(sql1, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) > 0)//班级存在
                {
                    MessageBox.Show("此班级已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else//添加进数据库
                {
                    string sql2 = "insert into Class set classId='" + banjiId + "',className='" + banjiName + "',classCount='" + renshu + "',teacher='"+banzhur+"',classExplain='"+shuoming+"',majorId='"+zhuanyeId+"'";
                    MySqlCommand com2 = new MySqlCommand(sql2, conn);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();                 
                }

               

            }
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
            //导入专业进集合

            MySqlCommand st = new MySqlCommand("select majorName from major", conn);
            MySqlDataReader reader1 = st.ExecuteReader();
            major.Items.Clear();
            while (reader1.Read())
            {
                major.Items.Add((string)reader1[0]);
            }
            reader1.Close();
        }
    }
}
