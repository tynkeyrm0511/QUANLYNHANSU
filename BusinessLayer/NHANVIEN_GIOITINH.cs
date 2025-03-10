using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NHANVIEN_GIOITINH
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_NHANVIEN_GIOITINH getItem(int id)
        {
            return db.tb_NHANVIEN_GIOITINH.FirstOrDefault(x => x.IDGT == id);
        }
        public List<tb_NHANVIEN_GIOITINH> getList()
        {
            return db.tb_NHANVIEN_GIOITINH.ToList();
        }
    }
}
