using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer;
namespace BusinessLayer
{
    public class NHANVIEN
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_NHANVIEN getItem(int id)
        {
            return db.tb_NHANVIEN.FirstOrDefault(x => x.MANV == id);
        }

        public List<tb_NHANVIEN> getList()
        {
            return db.tb_NHANVIEN.ToList();
        }
        public List<NHANVIEN_DTO> getListDTO() 
        {
            var lstNV = db.tb_NHANVIEN.ToList();
            List<NHANVIEN_DTO> lstNVDTO = new List<NHANVIEN_DTO>();
            NHANVIEN_DTO nvDTO;
            foreach (var item in lstNV)
            {
                nvDTO = new NHANVIEN_DTO();
                nvDTO.MANV = item.MANV;
                nvDTO.HOTEN = item.HOTEN;
                nvDTO.NGAYSINH = item.NGAYSINH;
                nvDTO.CCCD = item.CCCD;
                nvDTO.SDT = item.SDT;
                nvDTO.DIACHI = item.DIACHI;
                nvDTO.HINHANH = item.HINHANH;
                nvDTO.DATHOIVIEC = item.DATHOIVIEC;
                

                nvDTO.IDGT = item.IDGT;
                var gt = db.tb_NHANVIEN_GIOITINH.FirstOrDefault(s => s.IDGT == item.IDGT);
                nvDTO.TENGT = gt.TENGT;

                nvDTO.IDPB = item.IDPB;
                var pb=db.tb_PHONGBAN.FirstOrDefault(p=>p.IDPB == item.IDPB);
                nvDTO.TENPB = pb.TENPB;

                nvDTO.IDBP = item.IDBP;
                var bp=db.tb_BOPHAN.FirstOrDefault(b=>b.IDBP == item.IDBP);
                nvDTO.TENBP = bp.TENBP;

                nvDTO.IDCV = item.IDCV;
                var cv=db.tb_CHUCVU.FirstOrDefault(c=>c.IDCV == item.IDCV);
                nvDTO.TENCV = cv.TENCV;

                nvDTO.IDTD = item.IDTD;
                var td=db.tb_TRINHDO.FirstOrDefault(t=>t.IDTD == item.IDTD);
                nvDTO.TENTD = td.TENTD;

                nvDTO.IDTG = item.IDTG;
                var tg=db.tb_TONGIAO.FirstOrDefault(g=>g.IDTG == item.IDTG);
                nvDTO.TENTG = tg.TENTG;

                nvDTO.IDDT = item.IDDT;
                var dt=db.tb_DANTOC.FirstOrDefault(d=>d.IDDT == item.IDDT);
                nvDTO.TENDT = dt.TENDT;

                lstNVDTO.Add(nvDTO);
            }
            return lstNVDTO;
        }
        public tb_NHANVIEN Add(tb_NHANVIEN nv)
        {
            try
            {
                db.tb_NHANVIEN.Add(nv);
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
        public tb_NHANVIEN Update(tb_NHANVIEN nv)//Hàm sửa
        {
            try
            {
                var _nv = db.tb_NHANVIEN.FirstOrDefault(x => x.MANV == nv.MANV);
                _nv.HOTEN = nv.HOTEN;
                _nv.IDGT = nv.IDGT;
                _nv.CCCD = nv.CCCD;
                _nv.HINHANH = nv.HINHANH;
                _nv.DIACHI = nv.DIACHI;
                _nv.NGAYSINH = nv.NGAYSINH;
                _nv.DATHOIVIEC = nv.DATHOIVIEC;
                _nv.SDT = nv.SDT;
                _nv.IDPB = nv.IDPB;
                _nv.IDBP = nv.IDBP;
                _nv.IDCV = nv.IDCV;
                _nv.IDTD = nv.IDTD;
                _nv.IDTG = nv.IDTG;
                _nv.IDDT = nv.IDDT;
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex);
            }
        }
        public void Delete(int id)//Hàm xóa
        {
            try
            {
                var _nv = db.tb_NHANVIEN.FirstOrDefault(x => x.MANV == id);
                db.tb_NHANVIEN.Remove(_nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
    }
}
