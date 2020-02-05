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
    public partial class changeCkeck : Form
    {
        public changeCkeck()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //修改宿舍
            string dormID = textBox1.Text;       //住宿号
            DateTime CDate = this.dateTimePicker1.Value;       //检查时间
            string CStat = comboBox1.Text;     //检查情况
            string CRemark = richTextBox1.Text;      //备注

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(CStat))
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
          
            //修改
            cmd.CommandText = string.Format(@" UPDATE[DormMIS].[dbo].[CheckInfo]
                                                               SET[dormID] = '{0}'
                                                                  ,[CDate] = '{1}'
                                                                  ,[CStat] = '{2}'
                                                                  ,[CRemark] = '{3}'
                                                             WHERE dormID='{4}'", dormID, CDate, CStat, CRemark, dormID);
            //判断修改是否成功

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
