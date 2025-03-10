using Bunifu.UI.WinForms;
using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using NHANSU_UIUX.Reports;
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
    public partial class frmHopDong : DevExpress.XtraEditors.XtraForm
    {
        public frmHopDong()
        {
            InitializeComponent();

        }
        HOPDONGLAODONG _hdld;
        NHANVIEN _nhanvien;
        bool _themhopdong;
        string _sohd;
        string _MaxSoHD;
        void _showHide(bool hd)
        {
            btnThem.Enabled = hd;
            btnSua.Enabled = hd;
            btnXoa.Enabled = hd;
            btnIn.Enabled = hd;


            dtpNgayBatDau.Enabled = !hd;
            dtpNgayKetThuc.Enabled = !hd;
            dtpNgayKy.Enabled = !hd;
            sludNhanVien.Enabled = !hd;
            spinHSL.Enabled = !hd;
            spinLanKy.Enabled = !hd;
            btnDongYThemSua.Enabled = !hd;
            btnHuyThemSua.Enabled = !hd;
        }
        private void _reset()
        {
            txtSoHD.Text = string.Empty;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddMonths(6);
            dtpNgayKy.Value = DateTime.Now;
            sludNhanVien.Text = string.Empty;
            spinHSL.Text = "1";
            spinLanKy.Text = "1";
        }
        void loadData()
        {
            gvDanhSach.DataSource = _hdld.getListFull();
        }
        void saveData()
        {
            if (_themhopdong)
            {
                //SOHD :    00001/yyyy/HDLD
                //example:  11548/2024/HDLD
                var maxSoHD = _hdld.CurrentSoHD();
                int n = int.Parse(maxSoHD.Substring(0, 5)) + 1;

                tb_HOPDONG hd = new tb_HOPDONG();
                hd.SOHD = n.ToString("00000") + @"/2024/HDLD";
                hd.NGAYBD = dtpNgayBatDau.Value;
                hd.NGAYKT = dtpNgayKetThuc.Value;
                hd.NGAYKY = dtpNgayKy.Value;
                hd.THOIHAN = cbxThoiHan.Text;
                hd.HESOLUONG = int.Parse(spinHSL.Text);
                hd.LANKY = int.Parse(spinLanKy.Text);
                hd.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                hd.CREATED_BY = 1;
                hd.CREATED_DATE = DateTime.Now;
                _hdld.Add(hd);
            }
            else
            {
                var hd = _hdld.getItem(_sohd);
                hd.NGAYBD = dtpNgayBatDau.Value;
                hd.NGAYKT = dtpNgayKetThuc.Value;
                hd.NGAYKY = dtpNgayKy.Value;
                hd.THOIHAN = cbxThoiHan.Text;
                hd.HESOLUONG = double.Parse(spinHSL.Text);
                hd.LANKY = int.Parse(spinLanKy.Text);
                hd.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                hd.UPDATED_BY = 1;
                hd.UPDATED_DATE = DateTime.Now;
                _hdld.Update(hd);
            }
        }
        void loadNhanVien()
        {
            sludNhanVien.Properties.DataSource = _nhanvien.getList();
            sludNhanVien.Properties.ValueMember = "MANV";
            sludNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            _showHide(true);
            _hdld = new HOPDONGLAODONG();
            _nhanvien = new NHANVIEN();
            _themhopdong = false;
            loadNhanVien();
            loadData();
            _reset();
            splitContainer1.Panel1Collapsed = true;
            txtSoHD.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themhopdong = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themhopdong = false;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /* (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _hdld.Delete(_sohd, 1);
                loadData();
            }*/
            using (var confirmDialog = new ConfirmationDialog())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _hdld.Delete(_sohd, 1);
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

        private void btnIn_Click(object sender, EventArgs e)
        {
             HopDongLaoDong rpt = new HopDongLaoDong();
             rpt.ShowPreviewDialog();
        }

        private void btnDongYThemSua_Click(object sender, EventArgs e)
        {
            saveData();
            loadData();
            _themhopdong = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuyThemSua_Click(object sender, EventArgs e)
        {
            _themhopdong = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < gvDanhSach.Rows.Count)
            {
                DataGridViewRow selectedRow = gvDanhSach.Rows[rowIndex];
                _sohd = selectedRow.Cells["SOHD"].Value.ToString();

                var hd = _hdld.getItem(_sohd);

                txtSoHD.Text = _sohd;
                dtpNgayBatDau.Value = hd.NGAYBD.Value;
                dtpNgayKetThuc.Value = hd.NGAYKT.Value;
                dtpNgayKy.Value = hd.NGAYKY.Value;
                cbxThoiHan.Text = hd.THOIHAN.ToString();
                spinHSL.Text = hd.HESOLUONG.ToString();
                spinLanKy.Text = hd.LANKY.ToString();
                sludNhanVien.Text = hd.MANV.ToString();
            }
        }
        private void cbxThoiHan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxThoiHan.SelectedItem != null)
            {
                string selectedThoiHan = cbxThoiHan.SelectedItem.ToString();

                if (selectedThoiHan == "6 tháng")
                {
                    dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddMonths(6);
                }
                else if (selectedThoiHan == "12 tháng")
                {
                    dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddYears(1);
                }
                else if (selectedThoiHan == "24 tháng")
                {
                    dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddYears(2);
                }
                else if (selectedThoiHan == "36 tháng")
                {
                    dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddYears(3);
                }
                dtpNgayKetThuc.Refresh();
            }
        }

        private void gvDanhSach_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (gvDanhSach.Columns[e.ColumnIndex].Name == "DELETED_BY" && e.Value != null)
            {
                // Clear the cell
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Retrieve the image
                Image img = Properties.Resources.daxoa1;

                // Calculate the new size to fit the cell while maintaining the aspect ratio
                int maxWidth = e.CellBounds.Width - 4; // Padding for better visual
                int maxHeight = e.CellBounds.Height - 4; // Padding for better visual
                Size newSize = new Size(img.Width, img.Height);

                if (img.Width > maxWidth || img.Height > maxHeight)
                {
                    double ratioX = (double)maxWidth / img.Width;
                    double ratioY = (double)maxHeight / img.Height;
                    double ratio = Math.Min(ratioX, ratioY);

                    newSize = new Size((int)(img.Width * ratio), (int)(img.Height * ratio));
                }

                // Calculate the position to center the image
                int imgX = e.CellBounds.X + (e.CellBounds.Width - newSize.Width) / 2;
                int imgY = e.CellBounds.Y + (e.CellBounds.Height - newSize.Height) / 2;

                // Draw the image with the new size
                e.Graphics.DrawImage(img, imgX, imgY, newSize.Width, newSize.Height);

                // Prevent default content painting
                e.Handled = true;
            }
        }
    }
}