using BusinessLayer.DTO;
using BusinessLayer;
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
using DataLayer;
using Bunifu.Framework.UI;
using System.IO;
using Bunifu.UI.WinForms;

namespace NHANSU_UIUX
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        int _id;
        NHANVIEN _nhanvien;
        PHONGBAN _phongban;
        BOPHAN _bophan;
        CHUCVU _chucvu;
        TRINHDO _trinhdo;
        DANTOC _dantoc;
        TONGIAO _tongiao;
        NHANVIEN_GIOITINH _gioitinh;
        List<NHANVIEN_DTO> _lstNVDTO;
        bool _themnhanvien;
        void _showHide(bool nv)
        {
            btnDongYThemSua.Enabled = !nv;
            btnHuyThemSua.Enabled = !nv;
            txtHoTen.Enabled = !nv;
            txtCCCD.Enabled = !nv;
            txtSDT.Enabled = !nv;
            rtxtDiaChi.Enabled = !nv;
            cbxGioiTinh.Enabled = !nv;
            cbxPhongBan.Enabled = !nv;
            cbxBoPhan.Enabled = !nv;
            cbxChucVu.Enabled = !nv;
            cbxTrinhDo.Enabled = !nv;
            cbxDanToc.Enabled = !nv;
            cbxTonGiao.Enabled = !nv;
            dtpNgaySinh.Enabled = !nv;
            btnThemFileAnh.Enabled = !nv;

            btnThem.Enabled = nv;
            btnSua.Enabled = nv;
            btnXoa.Enabled = nv;
        }
        void loadData()
        {
            gvDanhSach.DataSource = _nhanvien.getListDTO();
            _lstNVDTO = _nhanvien.getListDTO();
        }
        void saveData()
        {
            if (_themnhanvien)
            {
                tb_NHANVIEN nv = new tb_NHANVIEN();
                nv.HOTEN = txtHoTen.Text;
                nv.IDGT = int.Parse(cbxGioiTinh.SelectedValue.ToString());
                nv.NGAYSINH = dtpNgaySinh.Value;
                nv.SDT = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = rtxtDiaChi.Text;
                nv.HINHANH = ImageToBase64(AnhDaiDien.Image, AnhDaiDien.Image.RawFormat);
                nv.IDPB = int.Parse(cbxPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cbxBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cbxChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cbxTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cbxDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cbxTonGiao.SelectedValue.ToString());
                _nhanvien.Add(nv);
            }
            else
            {
                var nv = _nhanvien.getItem(_id);
                nv.HOTEN = txtHoTen.Text;
                nv.IDGT = int.Parse(cbxGioiTinh.SelectedValue.ToString());
                nv.NGAYSINH = dtpNgaySinh.Value;
                nv.SDT = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = rtxtDiaChi.Text;
                nv.HINHANH = ImageToBase64(AnhDaiDien.Image, AnhDaiDien.Image.RawFormat);
                nv.IDPB = int.Parse(cbxPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cbxBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cbxChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cbxTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cbxDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cbxTonGiao.SelectedValue.ToString());
                _nhanvien.Update(nv);
            }
        }
        void _reset()
        {
            txtHoTen.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtSDT.Text = string.Empty;
            rtxtDiaChi.Text = string.Empty;
            AnhDaiDien.Image = Properties.Resources.chonfileanh_s;
        }
        void loadComboBoxData()
        {
            cbxGioiTinh.DataSource = _gioitinh.getList();
            cbxGioiTinh.DisplayMember = "TENGT";
            cbxGioiTinh.ValueMember = "IDGT";

            cbxPhongBan.DataSource = _phongban.getList();
            cbxPhongBan.DisplayMember = "TENPB";
            cbxPhongBan.ValueMember = "IDPB";

            cbxBoPhan.DataSource = _bophan.getList();
            cbxBoPhan.DisplayMember = "TENBP";
            cbxBoPhan.ValueMember = "IDBP";

            cbxChucVu.DataSource = _chucvu.getList();
            cbxChucVu.DisplayMember = "TENCV";
            cbxChucVu.ValueMember = "IDCV";

            cbxTrinhDo.DataSource = _trinhdo.getList();
            cbxTrinhDo.DisplayMember = "TENTD";
            cbxTrinhDo.ValueMember = "IDTD";

            cbxDanToc.DataSource = _dantoc.getList();
            cbxDanToc.DisplayMember = "TENDT";
            cbxDanToc.ValueMember = "IDDT";

            cbxTonGiao.DataSource = _tongiao.getList();
            cbxTonGiao.DisplayMember = "TENTG";
            cbxTonGiao.ValueMember = "IDTG";
        }
        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < gvDanhSach.Rows.Count)
            {
                DataGridViewRow selectedRow = gvDanhSach.Rows[rowIndex];
                _id = Convert.ToInt32(selectedRow.Cells["MANV"].Value.ToString());

                var nv = _nhanvien.getItem(_id);
                txtHoTen.Text = nv.HOTEN;
                cbxGioiTinh.SelectedValue = nv.IDGT;
                dtpNgaySinh.Value = nv.NGAYSINH ?? DateTime.Now;
                txtCCCD.Text = nv.CCCD;
                txtSDT.Text = nv.SDT;
                rtxtDiaChi.Text = nv.DIACHI;
                AnhDaiDien.Image = Base64ToImage(nv.HINHANH);
                cbxPhongBan.SelectedValue = nv.IDPB;
                cbxBoPhan.SelectedValue = nv.IDBP;
                cbxChucVu.SelectedValue = nv.IDCV;
                cbxTrinhDo.SelectedValue = nv.IDTD;
                cbxDanToc.SelectedValue = nv.IDDT;
                cbxTonGiao.SelectedValue = nv.IDTG;
            }
        }
     
        private void frmNhanVien_Load(object sender, EventArgs e)
        {

            _showHide(true);
            _nhanvien = new NHANVIEN();
            _phongban = new PHONGBAN();
            _bophan = new BOPHAN();
            _chucvu = new CHUCVU();
            _trinhdo = new TRINHDO();
            _dantoc = new DANTOC();
            _tongiao = new TONGIAO();
            _gioitinh = new NHANVIEN_GIOITINH();

            loadData();
            loadComboBoxData();
            splitContainer1.Panel1Collapsed = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themnhanvien = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themnhanvien = false;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //_nhanvien.Delete(_id);
            //loadData();
            using (var confirmDialog = new ConfirmationDialog())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _nhanvien.Delete(_id);
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
            _themnhanvien = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuyThemSua_Click(object sender, EventArgs e)
        {
            _themnhanvien = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }
        //Hàm chuyển đổi img thành mảng byte để lưu vào DB
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        //Hàm chuyển đổi mảng byte trở về img
        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnThemFileAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn file ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                AnhDaiDien.Image = Image.FromFile(openFile.FileName);
                AnhDaiDien.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void gvDanhSach_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if the current cell is not a header cell
            if (e.RowIndex >= 0 && gvDanhSach.Columns[e.ColumnIndex].Name == "DATHOIVIEC" && e.Value != null)
            {
                // Allow default background painting
                e.PaintBackground(e.ClipBounds, true);

                // Convert the cell value to a boolean
                bool isDaThoiViec = false;
                if (bool.TryParse(e.Value.ToString(), out bool result))
                {
                    isDaThoiViec = result;
                }

                // Draw the text based on the boolean value
                string displayText = isDaThoiViec ? "Đã thôi việc" : string.Empty;
                e.Graphics.DrawString(displayText, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), e.CellBounds.X + 2, e.CellBounds.Y + 2);

                // Indicate that the cell painting is handled to prevent default content painting
                e.Handled = true;
            }
            else
            {
                // Ensure that the default painting is used for header cells and other columns
                e.Handled = false;
            }
        }
    }   
}