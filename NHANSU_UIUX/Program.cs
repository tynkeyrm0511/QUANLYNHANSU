using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using NHANSU_UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHANSU_UIUX
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            // Hiển thị frmDangNhap trước
            frmLogin loginForm = new frmLogin();
            Application.Run(loginForm);
        }
    }
}
