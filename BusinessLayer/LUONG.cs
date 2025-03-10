using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LUONG
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public int GetSoNgayCong(int manv, int thang, int nam)
        {
            var bangCong = db.tb_BANGCONG.FirstOrDefault(b => b.MANV == manv && b.THANG == thang && b.NAM == nam);
            return bangCong?.SONGAYCONG ?? 0;
        }
        public tb_LUONG getItem(int id)
        {
            return db.tb_LUONG.FirstOrDefault(x => x.IDL == id);
        }
        public List<tb_LUONG> getList()
        {
            return db.tb_LUONG.ToList();
        }
        public List<LUONG_DTO> getListFull()
        {
            List<tb_LUONG> lstHD = db.tb_LUONG.ToList();
            List<LUONG_DTO> lstDTO = new List<LUONG_DTO>();
            LUONG_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new LUONG_DTO();
                hd.IDL = item.IDL;
                hd.SOTIEN = item.SOTIEN;
                hd.THANG = item.THANG;
                hd.NAM = item.NAM;
                hd.MANV = item.MANV;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.DELETED_BY = item.DELETED_BY;
                lstDTO.Add(hd);
            }
            return lstDTO;
        }
        public tb_LUONG Add(tb_LUONG bl)
        {
            try
            {
                db.tb_LUONG.Add(bl);
                db.SaveChanges();
                return bl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public tb_LUONG Update(tb_LUONG bl)
        {
            try
            {
                var _bl = db.tb_LUONG.FirstOrDefault(x => x.IDL == bl.IDL);
                _bl.SOTIEN = bl.SOTIEN;
                _bl.MANV = bl.MANV;
                _bl.THANG = bl.THANG;
                _bl.NAM = bl.NAM;
                db.SaveChanges();
                return bl;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var _bl = db.tb_LUONG.FirstOrDefault(x => x.IDL == id);
                db.tb_LUONG.Remove(_bl);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
    }
}
