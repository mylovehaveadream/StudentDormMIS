using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormMIS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            //添加检查
            addCheck check = new addCheck();//实例化
            check.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //添加用户
           addUser user = new addUser();//实例化
            user.Show(menuStrip1); //窗体展示
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //修改密码
            changePassword password = new changePassword();//实例化
            password.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //添加宿舍
            addDorm dorm = new addDorm();//实例化
            dorm.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //查询宿舍
            checkDorm cdorm = new checkDorm();//实例化
            cdorm.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //入住学生
            Student student = new Student();//实例化
            student.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //查询学生
            checkStudent cstudent = new checkStudent();//实例化
            cstudent.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            //查询检查
            check c = new check();//实例化
            c.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            //水电添加
            charge c = new charge();//实例化
            c.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            //水电查询
            checkCharge ccharge = new checkCharge();//实例化
            ccharge.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            //添加报修
            Repair repair = new Repair();//实例化
            repair.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            //查询保修
            checkRepair crepair = new checkRepair();//实例化
            crepair.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            //添加人员
            register r = new register();//实例化
            r.Show(menuStrip1); //窗体展示
        }

        private void ToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            //查询人员
            checkRegister cregister = new checkRegister();//实例化
            cregister.Show(menuStrip1); //窗体展示
        }
    }
}
