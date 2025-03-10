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
    public partial class frmKhenThuong : DevExpress.XtraEditors.XtraForm
    {
        public frmKhenThuong()
        {
            InitializeComponent();
        }
        KHENTHUONG_KYLUAT _kt;
        NHANVIEN _nhanvien;
        bool _themhopdong;
        string _soqd;
        string _MaxSoHD;
        void _showHide(bool hd)
        {
            btnThem.Enabled = hd;
            btnSua.Enabled = hd;
            btnXoa.Enabled = hd;
            btnIn.Enabled = hd;

            //dtpNgayBatDau.Enabled = !hd;
            //dtpNgayKetThuc.Enabled = !hd;
            dtpNgayKhenThuong.Enabled = !hd;
            sludNhanVien.Enabled = !hd;
            txtLyDo.Enabled = !hd;
            txtNoiDung.Enabled = !hd;
            btnDongYThemSua.Enabled = !hd;
            btnHuyThemSua.Enabled = !hd;
        }
        private void _reset()
        {
            txtLyDo.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
            txtSoQD.Text = string.Empty;
            //dtpNgayBatDau.Value = DateTime.Now;
            //dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddMonths(6);
            dtpNgayKhenThuong.Value = DateTime.Now;
            sludNhanVien.Text = string.Empty;

        }
        void loadData()
        {
            gvDanhSach.DataSource = _kt.getListFull(1);
        }
        void saveData()
        {
            if (_themhopdong)
            {
                //SOHD :    00001/yyyy/HDLD
                //example:  11548/2024/HDLD
                var maxSoQD = _kt.CurrentSoQD(1);
                int n = int.Parse(maxSoQD.Substring(0, 5)) + 1;
                tb_KHENTHUONG_KYLUAT kt = new tb_KHENTHUONG_KYLUAT();
                kt.SOQUYETDINH = n.ToString("00000") + @"/2024/QDKT";
                //hd.NGAYBD = dtpNgayBatDau.Value;
                //hd.NGAYKT = dtpNgayKetThuc.Value;
                kt.LOAI = 1;
                kt.NGAY = dtpNgayKhenThuong.Value;
                kt.LYDO = txtLyDo.Text;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                kt.CREATED_BY = 1;
                kt.CREATED_DATE = DateTime.Now;
                _kt.Add(kt);
            }
            else
            {
                var kt = _kt.getItem(_soqd);
                //hd.NGAYBD = dtpNgayBatDau.Value;
                //hd.NGAYKT = dtpNgayKetThuc.Value;
                kt.NGAY = dtpNgayKhenThuong.Value;
                kt.LYDO = txtLyDo.Text;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.MANV = int.Parse(sludNhanVien.EditValue.ToString());
                kt.CREATED_BY = 1;  
                kt.CREATED_DATE = DateTime.Now;
                _kt.Update(kt);
            }
        }
        void loadNhanVien()
        {
            sludNhanVien.Properties.DataSource = _nhanvien.getList();
            sludNhanVien.Properties.ValueMember = "MANV";
            sludNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            _showHide(true);
            _kt = new KHENTHUONG_KYLUAT();
            _nhanvien = new NHANVIEN();
            _themhopdong = false;
            loadNhanVien();
            loadData();
            _reset();
            splitContainer1.Panel1Collapsed = true;
            txtSoQD.Enabled = false;
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
                //_kt.Delete(_soqd,1);
               //loadData();
            
            using (var confirmDialog = new ConfirmationDialog())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _kt.Delete(_soqd, 1);
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
                _soqd = selectedRow.Cells["SOQUYETDINH"].Value.ToString();

                var kt = _kt.getItem(_soqd);

                txtSoQD.Text = _soqd;
                //dtpNgayBatDau.Value = kt.NGAYBD.Value;
                //dtpNgayKetThuc.Value = kt.NGAYKT.Value;
                dtpNgayKhenThuong.Value = kt.NGAY.Value;
                sludNhanVien.Text = kt.MANV.ToString();
                txtLyDo.Text = kt.LYDO.ToString();
                txtNoiDung.Text = kt.NOIDUNG.ToString();

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