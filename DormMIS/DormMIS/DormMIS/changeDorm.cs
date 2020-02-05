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
    public partial class changeDorm : Form
    {
        public changeDorm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //添加宿舍
            //获取用户输入的值
            string dormID = textBox1.Text;       //住宿号
            string dMoney = textBox2.Text;      //住宿费
            string chairNum = textBox3.Text;    //椅子数
            string phone = textBox4.Text;       //电话
            string bedNum = textBox5.Text;       //床位数
            string deskNum = textBox6.Text;       //桌子数
            string dRemark = richTextBox1.Text;    //备注 

            //判断住宿号输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(dMoney)
                || string.IsNullOrEmpty(chairNum) || string.IsNullOrEmpty(phone)
                || string.IsNullOrEmpty(bedNum) || string.IsNullOrEmpty(deskNum))
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

            //添加用户
            cmd.CommandText = string.Format(@"UPDATE [DormMIS].[dbo].[Dorm]
                                                       SET [dormID] ='{0}'
                                                          ,[phone] = '{1}'
                                                          ,[dMoney] = '{2}'
                                                          ,[bedNum] = '{3}'
                                                          ,[chairNum] = '{4}'
                                                          ,[deskNum] = '{5}'
                                                          ,[dRemark] ='{6}'
                                                     WHERE dormID = '{7}' ", dormID,phone, dMoney, bedNum, chairNum, deskNum, dRemark, dormID);

            int row_count = cmd.ExecuteNonQuery();//执行sql语句并返回受影响的行数
            //判断是否修改成功
            if (row_count != 1)
            {
                MessageBox.Show("修改不成功,请重新输入！");
            }
            else
            {
                MessageBox.Show("修改成功！");
            }

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
