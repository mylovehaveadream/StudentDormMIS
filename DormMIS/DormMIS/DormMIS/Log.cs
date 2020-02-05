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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //取消按钮
            DialogResult choice =
                MessageBox.Show("确定退出吗？", "输入提示", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
            if(choice == DialogResult.OK)
            {
                //退出程序
                Application.Exit();
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Log_KeyDown(object sender, KeyEventArgs e)
        {
            //鼠标的触碰
            if(e.KeyData == Keys.Return)//判断用户按下的是否是回车键
            {
                Login();
            }

        }

        private void Login()
        {
            //确定按钮
            //获取用户输入的值
            string uname = textBox1.Text;       //用户名
            string pwd = textBox2.Text;         //密码

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return; //不进行下一步的操作
            }

            //与数据库进行连接
            DormMIS dorm = new DormMIS();//实例化对象
            SqlConnection connection = dorm.OpenDorm();

            //创建命令对象，执行sql语句
            SqlCommand cmd = new SqlCommand();

            //设置命令的执行属性
            cmd.Connection = connection;

            //查询用户是否存在与表中
            cmd.CommandText = string.Format("select PWD from UserInfo where UName ='{0}'", uname);
            SqlDataReader dr = cmd.ExecuteReader();
            //判断是否用用户的存在
            if (dr.Read())
            {
                //判断密码是否与输入密码是否相同
                if (dr["PWD"].ToString() == pwd)
                {
                    //MessageBox.Show("登录成功！");
                    //FrmMain main = new FrmMain();   //显示主页面
                    //main.Show();
                    //this.Hide();    //进行一个的隐藏

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;   //相对应
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
            }
            else
            {
                MessageBox.Show("用户不存在，请重新输入！");
            }
            //关闭连接
            connection.Close();
        }
    }
}
