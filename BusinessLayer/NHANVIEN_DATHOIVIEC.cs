using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NHANVIEN_DATHOIVIEC
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_NHANVIEN_THOIVIEC getItem(string soqd)
        {
            return db.tb_NHANVIEN_THOIVIEC.FirstOrDefault(x=>x.SOQD==soqd);
        }
        public List<tb_NHANVIEN_THOIVIEC> getList()
        {
            return db.tb_NHANVIEN_THOIVIEC.ToList();
        }
        public List<NHANVIEN_DATHOIVIEC_DTO> getListFull()
        {
            List<tb_NHANVIEN_THOIVIEC> lstHD = db.tb_NHANVIEN_THOIVIEC.ToList();
            List<NHANVIEN_DATHOIVIEC_DTO> lstDTO = new List<NHANVIEN_DATHOIVIEC_DTO>();
            NHANVIEN_DATHOIVIEC_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new NHANVIEN_DATHOIVIEC_DTO();
                hd.SOQD = item.SOQD;
                hd.NGAYNGHI = item.NGAYNGHI;
                hd.NGAYNOPDON = item.NGAYNOPDON;
                hd.GHICHU = item.GHICHU;
                hd.LYDO = item.LYDO;
                hd.MANV = item.MANV;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(hd);
            }
            return lstDTO;
        }
        public tb_NHANVIEN_THOIVIEC Add(tb_NHANVIEN_THOIVIEC tv)
        {
            try
            {
                db.tb_NHANVIEN_THOIVIEC.Add(tv);
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex )
            {

                throw new Exception("Lỗi" + ex.Message);
            }
        }
        public tb_NHANVIEN_THOIVIEC Update(tb_NHANVIEN_THOIVIEC tv)
        {
            try
            {
                var _tv = db.tb_NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == tv.SOQD);
                _tv.NGAYNOPDON = tv.NGAYNOPDON;
                _tv.NGAYNGHI = tv.NGAYNGHI;
                _tv.MANV = tv.MANV;
                _tv.LYDO = tv.LYDO;
                _tv.GHICHU = tv.GHICHU;
                _tv.UPDATED_BY = tv.UPDATED_BY;
                _tv.UPDATED_DATE = tv.UPDATED_DATE;
                _tv.MANV = tv.MANV;
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex.Message);
            }
        }
        public void Delete(string soqd, int iduser)
        {
            try
            {
                var _tv = db.tb_NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == soqd);
                _tv.DELETED_BY = iduser;
                _tv.DELETED_DATE = DateTime.Now;
                db.SaveChanges() ;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CurrentSoHD()
        {
            var _hd = db.tb_NHANVIEN_THOIVIEC.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00000";

        }
    }
}
