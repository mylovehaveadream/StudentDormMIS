using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;  //把数据库引用进来
using System.Data.SqlClient;

namespace DormMIS
{
    class DormMIS
    {
        //创建连接数据库的方法
        public SqlConnection OpenDorm()
        {
            //与数据库进行连接

            //连接数据库
            string constr = "Data Source=.\\sqlexpress;Initial Catalog=DormMIS;Integrated Security=True";

            //创建连接对象
            SqlConnection connection = new SqlConnection(constr);

            //连接数据库
            connection.Open();

            return connection;
        }
    }
}
