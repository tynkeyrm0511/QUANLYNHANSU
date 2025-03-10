using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CHUCVU
    {
        QLNHANSUEntities db = new QLNHANSUEntities();

        public tb_CHUCVU getItem(int id)
        {
            return db.tb_CHUCVU.FirstOrDefault(x => x.IDCV == id);
        }

        public List<tb_CHUCVU> getList()
        {
            return db.tb_CHUCVU.ToList();
        }

        public tb_CHUCVU Add(tb_CHUCVU cv)//Hàm thêm
        {
            try
            {
                db.tb_CHUCVU.Add(cv);
                db.SaveChanges();
                return cv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
        public tb_CHUCVU Update(tb_CHUCVU cv)//Hàm sửa
        {
            try
            {
                var _cv = db.tb_CHUCVU.FirstOrDefault(x => x.IDCV == cv.IDCV);
                _cv.TENCV = cv.TENCV;
                db.SaveChanges();
                return cv;
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
                var _cv = db.tb_CHUCVU.FirstOrDefault(x => x.IDCV == id);
                db.tb_CHUCVU.Remove(_cv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi" + ex);
            }
        }
    }
}
