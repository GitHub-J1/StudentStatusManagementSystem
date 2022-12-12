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
    public partial class UpdateMajor : Form
    {
        public UpdateMajor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UpdateMajor_Load(object sender, EventArgs e)
        {
            textBox1.Text = BrowseMajor.t1;
            textBox2.Text = BrowseMajor.t2;
            textBox3.Text = BrowseMajor.t3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 连接数据库
            //定义连接字符串
            string connStr = "server=localhost;" +"database=studentstatusmanagement;" +"uid=root;" +"pwd=MySQL0977528;";;
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion
          
            //string newt1 = textBox1.Text;
            string newt2 = textBox2.Text;
            string newt3 = textBox3.Text;
            string sql="UPDATE major SET  majorName = '"+newt2+"', majorExplain = '"+newt3+"' WHERE majorid = '"+ BrowseMajor.array[BrowseMajor.index] + "'";
            MySqlCommand com = new MySqlCommand(sql, conn);
            com.ExecuteNonQuery();
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Hide();
        }
    }
}
