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
    public partial class charge : Form
    {
        public charge()
        {
            InitializeComponent();
        }

        private void Charge_Load(object sender, EventArgs e)
        {
           
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //添加
            string dormID = textBox1.Text;       //宿舍号
            DateTime MDate = this.dateTimePicker1.Value;         //缴费日期
            string EBuy = textBox2.Text;         //购买电量
            string CPerson = textBox4.Text;       //购买人
            string CMoney = textBox5.Text;       //价钱
            
            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(EBuy) || string.IsNullOrEmpty(CPerson)
                || string.IsNullOrEmpty(CMoney))
            {
                MessageBox.Show("不能为空！");
                return; //不进行下一步的操作
            }

            //与数据库进行连接
            DormMIS dorm = new DormMIS();//实例化对象-
            SqlConnection connection = dorm.OpenDorm();

            //创建命令对象，执行sql语句
            SqlCommand cmd = new SqlCommand();

            //设置命令的执行属性
            cmd.Connection = connection;

            //添加
            cmd.CommandText = string.Format(@"INSERT INTO [DormMIS].[dbo].[Charge]
                                                                   ([dormID]
                                                                   ,[MDate]
                                                                   ,[EBuy]
                                                                   ,[CPerson]
                                                                   ,[CMoney])
                                                             VALUES
                                                                   ('{0}'
                                                                   ,'{1}'
                                                                   ,'{2}'
                                                                   ,'{3}'
                                                                   ,'{4}'
                                                                    )", dormID, MDate, EBuy, CPerson, CMoney);

            //判断是否添加成功
            try
            {
                int row_count = cmd.ExecuteNonQuery();//执行sql语句，并返回受影响的行数。
            }
            catch (Exception ex)
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
