using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BANGCONG
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_BANGCONG getItem(int id)
        {
            return db.tb_BANGCONG.FirstOrDefault(x => x.MABC == id);
        }
        public List<tb_BANGCONG> getList()
        {
            return db.tb_BANGCONG.ToList();
        }
        public List<BANGCONG_DTO> getListFull()
        {
            List<tb_BANGCONG> lstHD = db.tb_BANGCONG.ToList();
            List<BANGCONG_DTO> lstDTO = new List<BANGCONG_DTO>();
            BANGCONG_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new BANGCONG_DTO();
                hd.MABC = item.MABC;
                hd.SONGAYCONG = item.SONGAYCONG;
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
        public tb_BANGCONG Add(tb_BANGCONG bc)
        {
            try
            {
                db.tb_BANGCONG.Add(bc);
                db.SaveChanges();
                return bc;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public tb_BANGCONG Update(tb_BANGCONG bc)
        {
            try
            {
                var _hd = db.tb_BANGCONG.FirstOrDefault(x => x.MABC == bc.MABC);
                _hd.SONGAYCONG = bc.SONGAYCONG;
                _hd.MANV = bc.MANV;
                _hd.THANG = bc.THANG;
                _hd.NAM = bc.NAM;
                db.SaveChanges();
                return bc;
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
                var _bc = db.tb_BANGCONG.FirstOrDefault(x => x.MABC == id);
                db.tb_BANGCONG.Remove(_bc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
    }
}
