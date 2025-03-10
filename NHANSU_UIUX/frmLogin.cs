using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using NHANSU_UI;
using NHANSU_UIUX.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHANSU_UIUX
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true;
            KeyPreview = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (var context = new DataLayer.QLNHANSUEntities())
            {
                var username = txtTaiKhoan.Text;
                var password = txtMatKhau.Text;
                var user = context.tb_ADMIN.SingleOrDefault(u => u.USERNAME == username && u.PASSWORD == password);
                if (user != null)
                {
                    MainForm f = new MainForm(); // Truyền username tới MainForm nếu cần
                    f.Show();
                    this.Hide(); // Ẩn frmDangNhap sau khi đăng nhập thành công
                }
                else
                {
                    using (var wrongPassForm = new WrongPassOrUserName())
                    {
                        wrongPassForm.ShowDialog(); // Hiển thị form thông báo
                    }
                }
            }
        }

        private void btnThoatDangNhap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}