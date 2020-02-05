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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //添加
            string dormID = textBox1.Text;                      //宿舍号
            DateTime DateCome = this.dateTimePicker1.Value;         //来访日期
            DateTime DateLeave = this.dateTimePicker2.Value;     //离开日期
            string PCome = textBox4.Text;                        //来访人           
            string PLook = textBox2.Text;                  //被访人
            string Remark = richTextBox1.Text;              //备注

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(PCome) || string.IsNullOrEmpty(PLook))
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
            cmd.CommandText = string.Format(@"INSERT INTO [DormMIS].[dbo].[Register]
                                                                       ([PCome]
                                                                       ,[DateCome]
                                                                       ,[PLook]
                                                                       ,[dormID]
                                                                       ,[DateLeave]
                                                                       ,[Remark])
                                                             VALUES
                                                                   ('{0}'
                                                                   ,'{1}'
                                                                   ,'{2}'
                                                                   ,'{3}'
                                                                   ,'{4}'
                                                                    ,'{5}')", PCome, DateCome, PLook, dormID, DateLeave, Remark);


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
