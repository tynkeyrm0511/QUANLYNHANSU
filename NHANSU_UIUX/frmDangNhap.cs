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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private async void btnThoatDangNhap_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
            this.Hide();
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {

        }

        private void btnTiktok_Click(object sender, EventArgs e)
        {

        }

        private void btnZalo_Click(object sender, EventArgs e)
        {

        }

        private async void btnThuNho_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            this.WindowState = FormWindowState.Minimized;
        }
    }
}