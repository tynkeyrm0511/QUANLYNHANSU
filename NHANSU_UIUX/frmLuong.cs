using Bunifu.UI.WinForms;
using BusinessLayer;
using DataLayer;
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
    public partial class frmLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmLuong()
        {
            InitializeComponent();
        }
        int _id;
        LUONG _bangluong;
        bool _thembangluong;
        private void frmLuong_Load(object sender, EventArgs e)
        {
            _showHide(true);
            _bangluong = new LUONG();
            _nhanvien = new NHANVIEN();
            _thembangluong = false;
            loadNhanVien();
            loadData();
            _reset();
            splitContainer1.Panel1Collapsed = true;
            txtMaLuong.Enabled = false;
            txtSoNgayCong_From_BangCong.Enabled = false;
            _isFirstLoad = false;

        }
        void _showHide(bool hd)
        {
            btnThem.Enabled = hd;
            btnSua.Enabled = hd;
            btnXoa.Enabled = hd;

            cbxNam.Enabled = !hd;
            cbxThang.Enabled = !hd;
            sludNhanVien.Enabled = !hd;
            btnDongYThemSua.Enabled = !hd;
            btnHuyThemSua.Enabled = !hd;
        }
        private void _reset()
        {
            txtMaLuong.Text = string.Empty;
            sludNhanVien.Text = string.Empty;
            cbxNam.Text = "2024";
            cbxThang.Text = "1";
        }
        void loadData()
        {
            gvDanhSach.DataSource = _bangluong.getListFull();
        }
        void saveData()
        {
            if (string.IsNullOrEmpty(sludNhanVien.EditValue?.ToString()))
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbxThang.Text))
            {
                MessageBox.Show("Tháng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbxNam.Text))
            {
                MessageBox.Show("Năm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSoNgayCong_From_BangCong.Text) == 0)
            {
                MessageBox.Show("Số ngày công bằng 0 tức là bạn không có ngày công nào để tính tiền lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int manv = int.Parse(sludNhanVien.EditValue.ToString());
            int thang = int.Parse(cbxThang.Text);
            int nam = int.Parse(cbxNam.Text);
            float luongCoBan = float.Parse(txtLuongCoBan.Text);
            int soNgayCong = _bangluong.GetSoNgayCong(manv, thang, nam);
            float soTien = luongCoBan * soNgayCong;
            if (_thembangluong)
            {
                tb_LUONG bl = new tb_LUONG();
                bl.SOTIEN = soTien;
                bl.MANV = manv;
                bl.THANG = thang;
                bl.NAM = nam;
                _bangluong.Add(bl);
            }
            else
            {
                var bl = _bangluong.getItem(_id);
                bl.SOTIEN = soTien;
                bl.MANV = manv;
                bl.THANG = thang;
                bl.NAM = nam;
                _bangluong.Update(bl);
            }
        }
        NHANVIEN _nhanvien;
        void loadNhanVien()
        {
            sludNhanVien.Properties.DataSource = _nhanvien.getList();
            sludNhanVien.Properties.ValueMember = "MANV";
            sludNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _thembangluong = true;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _thembangluong = false;
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
                        _bangluong.Delete(_id);
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
            _thembangluong = false;
            splitContainer1.Panel1Collapsed = true;

        }
        private void btnHuyThemSua_Click(object sender, EventArgs e)
        {
            _showHide(true);
            _thembangluong = false;
            splitContainer1.Panel1Collapsed = true;
        }

        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < gvDanhSach.Rows.Count)
            {
                DataGridViewRow selectedRow = gvDanhSach.Rows[rowIndex];
                _id = Convert.ToInt32(selectedRow.Cells["IDL"].Value.ToString());
                txtSoTien.Text = selectedRow.Cells["SOTIEN"].Value.ToString();
                cbxThang.Text = selectedRow.Cells["THANG"].Value.ToString();
                cbxNam.Text = selectedRow.Cells["NAM"].Value.ToString();
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoNgayCong_From_BangCong.Text) && !string.IsNullOrEmpty(txtLuongCoBan.Text))
            {
                // Lấy số ngày công từ txtSoNgayCong_From_BangCong và lương cơ bản từ txtLuongCoBan
                int soNgayCong = int.Parse(txtSoNgayCong_From_BangCong.Text);
                float luongCoBan = float.Parse(txtLuongCoBan.Text);

                // Tính số tiền
                float soTien = soNgayCong * luongCoBan;

                // Hiển thị số tiền trong txtSoTien
                txtSoTien.Text = soTien.ToString("N0");
            }
            else
            {
                // Hiển thị thông báo lỗi nếu một trong hai trường trống
                MessageBox.Show("Vui lòng nhập số ngày công và lương cơ bản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool _isFirstLoad = true;

        private void sludNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            if (!_isFirstLoad)
            {
                // Kiểm tra nếu EditValue không null để tránh lỗi
                if (sludNhanVien.EditValue != null)
                {
                    int manv = Convert.ToInt32(sludNhanVien.Properties.View.GetFocusedRowCellValue("MANV"));
                    if (int.TryParse(cbxThang.Text, out int thang) && int.TryParse(cbxNam.Text, out int nam))
                    {
                        // Gọi phương thức GetSoNgayCong để lấy số ngày công
                        int soNgayCong = _bangluong.GetSoNgayCong(manv, thang, nam);

                        // Hiển thị số ngày công trong txtSoNgayCong_From_BangCong
                        txtSoNgayCong_From_BangCong.Text = soNgayCong.ToString();
                        txtSoNgayCong_From_BangCong.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn tháng và năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isFirstLoad)
            {
                UpdateSoNgayCong();
            }
        }
        private void cbxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isFirstLoad)
            {
                UpdateSoNgayCong();
            }
        }
        private void UpdateSoNgayCong()
        {
            // Kiểm tra nếu EditValue không null để tránh lỗi
            if (sludNhanVien.EditValue != null)
            {
                int manv = Convert.ToInt32(sludNhanVien.Properties.View.GetFocusedRowCellValue("MANV"));
                if (int.TryParse(cbxThang.Text, out int thang) && int.TryParse(cbxNam.Text, out int nam))
                {
                    // Gọi phương thức GetSoNgayCong để lấy số ngày công
                    int soNgayCong = _bangluong.GetSoNgayCong(manv, thang, nam);

                    // Hiển thị số ngày công trong txtSoNgayCong_From_BangCong
                    txtSoNgayCong_From_BangCong.Text = soNgayCong.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tháng và năm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}