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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //学生入住
            //获取学生输入的值
            string dormID = textBox1.Text;       //住宿号
            string SName = textBox2.Text;       //姓名
            string Class = textBox3.Text;     //班级
            string SID = textBox4.Text;      //学号
            string Sex = comboBox1.Text;    //性别

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(SName)
                || string.IsNullOrEmpty(Class) || string.IsNullOrEmpty(SID) || string.IsNullOrEmpty(Sex))
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
            cmd.CommandText = string.Format(@"INSERT INTO [DormMIS].[dbo].[Student]
                                                                   ([SID]
                                                                   ,[SName]
                                                                   ,[Sex]
                                                                   ,[Class]
                                                                   ,[dormID])
                                                         VALUES
                                                                 ('{0}'
                                                                 , '{1}'
                                                                 ,'{2}'
                                                                 ,'{3}'
                                                                 ,'{4}')", SID, SName, Sex, Class, dormID);
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
