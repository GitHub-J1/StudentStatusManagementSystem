using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentStatusManagementSyatem
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void 添加专业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            //打开添加专业窗口
            page.Text = "添加专业";
            AddProfessional stu = new AddProfessional();
            stu.Show();
            

        }

        private void 专业浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //打开浏览专业窗口
            page.Text = "专业浏览";
            BrowseMajor stu = new BrowseMajor();
            stu.Show();
        }

        private void 添加课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Tool.isTeacher==false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            page.Text = "添加课程";
            AddCourse stu = new AddCourse();
            stu.Show();

        }

        private void 课程浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page.Text = "课程浏览";
            BrowseCourse stu = new BrowseCourse();
            stu.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            register stu = new register();
            stu.Show();
        }

        private void 班级浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseClass stu = new BrowseClass();
            stu.Show();
            page.Text = "班级浏览";
        }

        private void 添加班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            AddClass stu = new AddClass();
            stu.Show();
            page.Text = "添加班级";
        }

        private void 添加学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            page.Text = "添加学生";
            AddStudent stu = new AddStudent();
            stu.Show();

        }

        private void 学生浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page.Text = "学生预览";
            BrowseStudent stu = new BrowseStudent();
            stu.Show();
        }

        private void 录入成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tool.isTeacher == false)
            {
                MessageBox.Show("对不起，您不是老师，没有权限执行此操作。");
                return;
            }
            page.Text = "录入成绩";
            AddScore stu = new AddScore();
            stu.Show();
        }

        private void 成绩浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page.Text = "成绩浏览";
            BrowseScore stu = new BrowseScore();
            stu.Show();

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
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
