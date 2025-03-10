using DevExpress.XtraEditors;
using NHANSU_UI;
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
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtMatKhauMoi2.UseSystemPasswordChar = true;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (var context = new DataLayer.QLNHANSUEntities())
            {
                var username = txtTaiKhoan.Text;
                var oldPassword = txtMatKhau.Text;
                var newPassword = txtMatKhauMoi.Text;
                var confirmPassword = txtMatKhauMoi2.Text; 
                // Kiểm tra mật khẩu mới và mật khẩu xác nhận có khớp nhau không
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Không tiếp tục nếu mật khẩu không khớp nhau
                }
                // Kiểm tra mật khẩu hiện tại của người dùng
                var user = context.tb_ADMIN.SingleOrDefault(u => u.USERNAME == username && u.PASSWORD == oldPassword);
                if (user != null)
                {
                    // Cập nhật mật khẩu mới
                    user.PASSWORD = newPassword;
                    context.SaveChanges();
                    txtTaiKhoan.Text = string.Empty;
                    txtMatKhau.Text = string.Empty;
                    txtMatKhauMoi.Text = string.Empty;
                    txtMatKhauMoi2.Text = string.Empty;
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtMatKhauMoi.Text = string.Empty;
            txtMatKhauMoi2.Text = string.Empty;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }
    }
}