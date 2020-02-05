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
    public partial class checkStudent : Form
    {
        public checkStudent()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void CheckStudent_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //查询
            string dormID = textBox3.Text;       //住宿号
            string SID = textBox1.Text;        //学号
            string SName = textBox2.Text;         //姓名     

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID)|| string.IsNullOrEmpty(SID) || string.IsNullOrEmpty(SName))
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

            //查询信息
            cmd.CommandText = string.Format(@"SELECT [SID]
                                                      ,[SName]
                                                      ,[Sex]
                                                      ,[Class]
                                                      ,[dormID]
                                                  FROM [DormMIS].[dbo].[Student]
                                                    WHERE dormID='{0}' and SID = '{1}' and SName ='{2}'", dormID, SID, SName);
            //进行返回页面
            SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, connection);
            DataSet ds = new DataSet();
            //填充数据源
            adapter.Fill(ds, "Student");
            //获取数据源中的表
            this.dataGridView1.DataSource = ds.Tables["Student"];

            SqlDataReader dr = cmd.ExecuteReader();
            //判断是否用查询到用户的
            if (dr.Read())
            {
                MessageBox.Show("查询成功！");
            }
            else
            {
                MessageBox.Show("没有查询到信息！");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            //退舍，删除
            string dormID = textBox3.Text;       //住宿号
            string SID = textBox1.Text;        //学号
            string SName = textBox2.Text;         //姓名     

            //判断用户输入是否为空值
            if (string.IsNullOrEmpty(dormID) || string.IsNullOrEmpty(SID) || string.IsNullOrEmpty(SName))
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

            //删除信息
            cmd.CommandText = string.Format(@"DELETE FROM [DormMIS].[dbo].[Student]
                                                             WHERE dormID='{0}' and SID = '{1}' and SName ='{2}'", dormID, SID, SName);
       
            //检查是否删除成功
            try
            {
                int row_count = cmd.ExecuteNonQuery();//执行sql语句，并返回受影响的行数。
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到指定的学生，退舍失败！");
                return;
            }
            MessageBox.Show("删除成功！");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //修改学生
            changeStudent cstudent = new changeStudent();//实例化
            cstudent.Show(); //窗体展示
        }
    }
}
