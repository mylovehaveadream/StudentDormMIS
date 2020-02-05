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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //添加用户
            //获取用户输入的值
            string uname = textBox1.Text;       //用户名
            string pwd = textBox2.Text;         //密码
            string pwd2 = textBox3.Text;         //密码

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return; //不进行下一步的操作
            }

            //判断密码是否相同
            if(pwd != pwd2)
            {
                MessageBox.Show("你前后输入的密码是不一样的，请重新输入！");
                return;
            }

            //与数据库进行连接
            DormMIS dorm = new DormMIS();//实例化对象-
            SqlConnection connection = dorm.OpenDorm();

            //创建命令对象，执行sql语句
            SqlCommand cmd = new SqlCommand();

            //设置命令的执行属性
            cmd.Connection = connection;

            //添加用户
            cmd.CommandText = string.Format(@"INSERT INTO [DormMIS].[dbo].[UserInfo]
                                                                ([UName]
                                                                 ,[PWD])
                                                         VALUES
                                                                 ('{0}'
                                                                 , '{1}'
                                                                  )", uname,pwd);

            //判断是否添加成功
            try
            {
                int row_count = cmd.ExecuteNonQuery();//执行sql语句，并返回受影响的行数。
            }
            catch(Exception ex)
            {
                MessageBox.Show("添加失败！");
                return;
            }
            MessageBox.Show("添加成功！");  
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //退出按钮
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
