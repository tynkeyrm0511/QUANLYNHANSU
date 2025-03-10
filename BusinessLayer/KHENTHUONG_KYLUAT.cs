using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KHENTHUONG_KYLUAT
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_KHENTHUONG_KYLUAT getItem(string soQD)
        {
            return db.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQUYETDINH == soQD);
        }

        // Loại 1 = khen thưởng
        // Loại 2 = khen thưởng
        public List<tb_KHENTHUONG_KYLUAT> getList(int loai) 
        {
            return db.tb_KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
        }
        public List<KHENTHUONG_KYLUAT_DTO> getListFull(int loai)
        {
            List<tb_KHENTHUONG_KYLUAT> lstKTKL = db.tb_KHENTHUONG_KYLUAT.Where(x=>x.LOAI==loai).ToList();
            List<KHENTHUONG_KYLUAT_DTO> lstDTO = new List<KHENTHUONG_KYLUAT_DTO>();
            KHENTHUONG_KYLUAT_DTO kt;
            foreach (var item in lstKTKL)
            {
                kt = new KHENTHUONG_KYLUAT_DTO();
                kt.SOQUYETDINH = item.SOQUYETDINH;
                kt.NGAY = item.NGAY;
                kt.TUNGAY = item.TUNGAY;
                kt.DENNGAY = item.DENNGAY;
                kt.NOIDUNG = item.NOIDUNG;
                kt.LOAI = item.LOAI;
                kt.LYDO = item.LYDO;

                kt.MANV = item.MANV;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                kt.HOTEN = nv.HOTEN;

                kt.CREATED_BY = item.CREATED_BY;
                kt.CREATED_DATE = item.CREATED_DATE;
                kt.UPDATED_BY = item.UPDATED_BY;
                kt.UPDATED_DATE = item.UPDATED_DATE;
                kt.DELETED_BY = item.DELETED_BY;
                kt.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(kt);
            }
            return lstDTO;
        }
        public tb_KHENTHUONG_KYLUAT Add(tb_KHENTHUONG_KYLUAT ktkl)
        {
            try
            {
                db.tb_KHENTHUONG_KYLUAT.Add(ktkl);
                db.SaveChanges();
                return ktkl;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex.Message);
            }
            
        }
        public tb_KHENTHUONG_KYLUAT Update(tb_KHENTHUONG_KYLUAT ktkl)
        {
            try
            {
                tb_KHENTHUONG_KYLUAT _ktkl = db.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQUYETDINH == ktkl.SOQUYETDINH);
                _ktkl.NGAY=ktkl.NGAY;
                _ktkl.TUNGAY=ktkl.TUNGAY;
                _ktkl.DENNGAY=ktkl.DENNGAY;
                _ktkl.LYDO=ktkl.LYDO;
                _ktkl.NOIDUNG=ktkl.NOIDUNG;
                _ktkl.LOAI=ktkl.LOAI;
                _ktkl.MANV=ktkl.MANV;
                _ktkl.UPDATED_BY=ktkl.UPDATED_BY;
                _ktkl.UPDATED_DATE=ktkl.UPDATED_DATE;
                db.SaveChanges();
                return ktkl;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex.Message);
            }

        }
        public void Delete(string soQD, int maNV)
        {
            try
            {
                tb_KHENTHUONG_KYLUAT _ktkl = db.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQUYETDINH == soQD);
                _ktkl.DELETED_DATE = DateTime.Now;
                _ktkl.DELETED_BY = maNV;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CurrentSoQD(int loai)
        {
            var _hd = db.tb_KHENTHUONG_KYLUAT.Where(x=>x.LOAI==loai).OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQUYETDINH;
            }
            else
                return "00000";

        }
    }
}
