using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormMIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log frm = new Log();
            if (frm.ShowDialog() == DialogResult.OK)    //先把登录窗体打开，然后判断是否为ok，再打开主窗口
            {
                Application.Run(new FrmMain());
            }
            
        }
    }
}
