using Bunifu.UI.WinForms;
using BusinessLayer;
using DataLayer;
using DevExpress.Data.Helpers;
using DevExpress.XtraEditors;
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
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangCong()
        {
            InitializeComponent();
        }
        int _id;
        BANGCONG _bangcong;
        bool _thembangcong;

        void _showHide(bool hd)
        {
           btnThem.Enabled = hd;
           btnSua.Enabled = hd;
           btnXoa.Enabled = hd;

           txtSoNgayCong.Enabled = !hd;
           cbxNam.Enabled = !hd;
           cbxThang.Enabled = !hd;
           sludNhanVien.Enabled = !hd;
           btnDongYThemSua.Enabled = !hd;
           btnHuyThemSua.Enabled = !hd;
        }
        private void _reset()
        {
            txtMACONG.Text = string.Empty;
            sludNhanVien.Text = string.Empty;
            txtSoNgayCong.Text = string.Empty;
            cbxNam.Text = "2024";
            cbxThang.Text = "1";
        }
        void loadData()
        {
           gvDanhSach.DataSource = _bangcong.getListFull();
        }
        void saveData()
        {
            if (_thembangcong)
            {
                tb_BANGCONG bc = new tb_BANGCONG();
                bc.SONGAYCONG = int.Parse(txtSoNgayCong.Text);
                bc.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                bc.THANG = int.Parse(cbxThang.Text);
                bc.NAM = int.Parse(cbxNam.Text);
                _bangcong.Add(bc);
            }
            else
            {
                var bc = _bangcong.getItem(_id);
                bc.SONGAYCONG = int.Parse(txtSoNgayCong.Text);
                bc.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                bc.THANG = int.Parse(cbxThang.Text);
                bc.NAM = int.Parse(cbxNam.Text);
                _bangcong.Update(bc);
            }
        }
        NHANVIEN _nhanvien;
        void loadNhanVien()
        {
           sludNhanVien.Properties.DataSource = _nhanvien.getList();
           sludNhanVien.Properties.ValueMember = "MANV";
           sludNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void frmBangCong_Load_1(object sender, EventArgs e)
        {
            _showHide(true);
            _bangcong = new BANGCONG();
            _nhanvien = new NHANVIEN();
            _thembangcong = false;
            loadNhanVien();
            loadData();
            _reset();
            splitContainer1.Panel1Collapsed = true;
            txtMACONG.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _thembangcong = true;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _thembangcong = false;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var confirmDialog = new ConfirmationDialog())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _bangcong.Delete(_id);
                        loadData();

                        // Hiển thị thông báo sử dụng Snackbar
                        notiThongBao.Show(this, "Xóa thành công!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.MiddleCenter);

                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                        notiThongBao.Show(this, "Có lỗi xảy ra: Bạn không thể xóa danh mục này vì nó đang tồn tại trong dữ liệu của một nhân viên nào đó, hãy sửa danh mục này ở nhân viên trước!", BunifuSnackbar.MessageTypes.Error, 3000, "", BunifuSnackbar.Positions.MiddleCenter);
                    }
                }
            }
        }

        private void btnDongYThemSua_Click(object sender, EventArgs e)
        {
            saveData();
            loadData();
            _showHide(true);
            _thembangcong = false;
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuyThemSua_Click(object sender, EventArgs e)
        {
            _showHide(true);
            _thembangcong = false;
            splitContainer1.Panel1Collapsed = true;
        }

        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < gvDanhSach.Rows.Count)
            {
                DataGridViewRow selectedRow = gvDanhSach.Rows[rowIndex];
                _id = Convert.ToInt32(selectedRow.Cells["MABC"].Value.ToString());
                txtSoNgayCong.Text = selectedRow.Cells["SONGAYCONG"].Value.ToString();
                cbxThang.Text = selectedRow.Cells["THANG"].Value.ToString();
                cbxNam.Text = selectedRow.Cells["NAM"].Value.ToString();
            }
        }
    }
}