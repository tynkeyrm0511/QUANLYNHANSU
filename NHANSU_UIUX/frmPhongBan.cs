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
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }
        int _id;
        PHONGBAN _phongban;
        bool _themphongban;
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            _phongban = new PHONGBAN();
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;
        }
        void _showHide(bool dt)
        {
            btnDongYThemSua.Enabled = !dt;
            btnHuyThemSua.Enabled = !dt;
            txtThemSua.Enabled = !dt;

            btnThem.Enabled = dt;
            btnSua.Enabled = dt;
            btnXoa.Enabled = dt;
        }
        void loadData()
        {
            gvDanhSach.DataSource = _phongban.getList();
        }
        void saveData()
        {

            if (_themphongban)
            {
                tb_PHONGBAN dt = new tb_PHONGBAN();
                dt.TENPB = txtThemSua.Text;
                _phongban.Add(dt);
            }
            else
            {
                var dt = _phongban.getItem(_id);
                dt.TENPB = txtThemSua.Text;
                _phongban.Update(dt);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themphongban = true;
            txtThemSua.Text = string.Empty;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(false);
            _themphongban = false;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // _phongban.Delete(_id);
            // loadData();
            using (var confirmDialog = new ConfirmationDialog())
            {
                var result = confirmDialog.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _phongban.Delete(_id);
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
            _themphongban = false;
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuyThemSua_Click(object sender, EventArgs e)
        {
            _showHide(true);
            _themphongban = false;
            splitContainer1.Panel1Collapsed = true;
        }

        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < gvDanhSach.Rows.Count)
            {
                DataGridViewRow selectedRow = gvDanhSach.Rows[rowIndex];
                _id = Convert.ToInt32(selectedRow.Cells["IDPB"].Value.ToString());
                txtThemSua.Text = selectedRow.Cells["TENPB"].Value.ToString();
            }
        }
    }
}