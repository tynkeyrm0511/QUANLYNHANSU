using Bunifu.UI.WinForms;
using DevExpress.Utils.Extensions;
using NHANSU_UIUX;
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

namespace NHANSU_UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        public MainForm()
        {
            InitializeComponent();
            UpdateLabelPosition();
        }
        private void paneltest_SizeChanged(object sender, EventArgs e)
        {
            UpdateLabelPosition();
        }
        private void UpdateLabelPosition()
        {
            // Calculate the X coordinate to center the label horizontally
            int x = (panel1.Width - lblFormHienTai.Width) / 2;
            // Make sure the label sticks to the top
            int y = 0;
            // Set the new location of the label
            lblFormHienTai.Location = new System.Drawing.Point(x, y);
        }
        private async void btnThoatPhanMem_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            this.Close();
        }

        private async void btnThuNho_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            this.WindowState = FormWindowState.Minimized;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
                currentFormChild.Close();
            lblFormHienTai.Text = "TRANG CHỦ";
        }
        private void shortcutNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            lblFormHienTai.Text = "DANH SÁCH NHÂN VIÊN";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            lblFormHienTai.Text = "DANH SÁCH NHÂN VIÊN";
        }

        private void btnTonGiao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTonGiao());
            lblFormHienTai.Text = "DANH MỤC TÔN GIÁO";
        }

        private void btnDanToc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanToc());
            lblFormHienTai.Text = "DANH MỤC DÂN TỘC";
        }

        private void btnTrinhDo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrinhDo());
            lblFormHienTai.Text = "DANH MỤC TRÌNH ĐỘ";
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPhongBan());
            lblFormHienTai.Text = "DANH MỤC PHÒNG BAN";
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBoPhan());
            lblFormHienTai.Text = "DANH MỤC BỘ PHẬN";
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChucVu());
            lblFormHienTai.Text = "DANH MỤC CHỨC VỤ";
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHopDong());
            lblFormHienTai.Text = "DANH SÁCH HỢP ĐỒNG";
        }
        private void shortcutHopDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHopDong());
            lblFormHienTai.Text = "DANH SÁCH HỢP ĐỒNG";
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhenThuong());
            lblFormHienTai.Text = "DANH SÁCH KHEN THƯỞNG";
        }
        private void shortcutKhenThuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhenThuong());
            lblFormHienTai.Text = "DANH SÁCH KHEN THƯỞNG";
        }
        private void btnKyLuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKyLuat());
            lblFormHienTai.Text = "DANH SÁCH KỶ LUẬT";
        }

        private void btnThoiViec_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien_ThoiViec());
            lblFormHienTai.Text = "DANH SÁCH THÔI VIỆC";
        }

        private void btnBangCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBangCong());
            lblFormHienTai.Text = "DANH SÁCH BẢNG CÔNG";
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLuong());
            lblFormHienTai.Text = "DANH SÁCH LƯƠNG";
        }

        private void shortcutLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLuong());
            lblFormHienTai.Text = "DANH SÁCH LƯƠNG";
        }

        private async void btnDangXuat_Click(object sender, EventArgs e)
        {
            using (var confirmDialog = new LogoutConfirm())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    await Task.Delay(300);
                    this.Hide();
                    using (frmLogin loginForm = new frmLogin())
                    {
                        loginForm.ShowDialog();
                    }
                    
                }

            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChangePassword());
            lblFormHienTai.Text = "ĐỔI MẬT KHẨU";
        }

        private  void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
