using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HOPDONGLAODONG
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_HOPDONG getItem(string sohd)
        {
            return db.tb_HOPDONG.FirstOrDefault(x=>x.SOHD == sohd);
        }
        public List<tb_HOPDONG> getList() 
        { 
            return db.tb_HOPDONG.ToList();
        }
        public List<HOPDONG_DTO> getListFull()
        {
            List<tb_HOPDONG> lstHD = db.tb_HOPDONG.ToList();
            List<HOPDONG_DTO> lstDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                hd.NGAYBD = item.NGAYBD;
                hd.NGAYKT = item.NGAYKT;
                hd.NGAYKY = item.NGAYKY;
                hd.LANKY = item.LANKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.MANV = item.MANV;
                hd.THOIHAN = item.THOIHAN;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n=>n.MANV==item.MANV);
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
        public tb_HOPDONG Add(tb_HOPDONG hd)
        {
            try
            {
                db.tb_HOPDONG.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public tb_HOPDONG Update(tb_HOPDONG hd)
        {
            try
            {
                var _hd = db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == hd.SOHD);
                _hd.NGAYBD = hd.NGAYBD;
                _hd.NGAYKT = hd.NGAYKT;
                _hd.MANV = hd.MANV;
                _hd.NGAYKY = hd.NGAYKY;
                _hd.LANKY = hd.LANKY;
                _hd.HESOLUONG = hd.HESOLUONG;
                _hd.NOIDUNG = hd.NOIDUNG;
                _hd.THOIHAN = hd.THOIHAN;
                _hd.SOHD = hd.SOHD;

                _hd.UPDATED_BY = hd.UPDATED_BY;
                _hd.UPDATED_DATE = hd.UPDATED_DATE;
                _hd.DELETED_BY = hd.DELETED_BY;
                _hd.DELETED_DATE = hd.DELETED_DATE;

                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Delete(string sohd, int manv)
        {
            var _hd = db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == sohd);
           
            _hd.DELETED_BY = manv;
            _hd.DELETED_DATE = DateTime.Now;

            db.SaveChanges();
        }
        public string CurrentSoHD()
        {
            var _hd = db.tb_HOPDONG.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if(_hd != null)
            {
                return _hd.SOHD;
            }
            else
                return "00000";
            
        }
    }
}
