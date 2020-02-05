using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;  //把数据库引用进来
using System.Data.SqlClient;

namespace DormMIS
{
    public partial class addCheck : Form
    {
        public addCheck()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //添加检查
            string dormID = textBox1.Text;       //住宿号
            DateTime CDate = this.dateTimePicker1.Value;       //检查时间
            string CStat = comboBox1.Text;     //检查情况
            string CRemark = richTextBox1.Text;      //备注

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID)|| string.IsNullOrEmpty(CStat))
            {
                MessageBox.Show("不能为空！");
                return; //不进行下一步的操作
            }

            //与数据库进行连接
            DormMIS dorm = new DormMIS();//实例化对象
            SqlConnection connection = dorm.OpenDorm();

            //创建命令对象，执行sql语句
            SqlCommand cmd = new SqlCommand();

            //设置命令的执行属性
            cmd.Connection = connection;

            //添加学生
            cmd.CommandText = string.Format(@"INSERT INTO [DormMIS].[dbo].[CheckInfo]
                                                               ([dormID]
                                                               ,[CDate]
                                                               ,[CStat]
                                                               ,[CRemark])                                                  
                                                         VALUES
                                                                 ('{0}'
                                                                 , '{1}'
                                                                 ,'{2}'
                                                                 ,'{3}')", dormID, CDate, CStat, CRemark);

            //判断添加是否成功
            try
            {
                int row_count = cmd.ExecuteNonQuery();//执行sql语句，并返回受影响的行数。
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败,没有找到指定的宿舍,请重新输入！");
                return;
            }
            MessageBox.Show("添加成功！");  
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCheck_Load(object sender, EventArgs e)
        {
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //取消按钮
            DialogResult choice =
                MessageBox.Show("确定退出吗？", "输入提示", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
            if (choice == DialogResult.OK)
            {
                //退出程序
                Application.Exit();
            }
        }
    }
}
