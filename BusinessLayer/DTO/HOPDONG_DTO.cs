using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class HOPDONG_DTO
    {
        public string SOHD { get; set; }
        public Nullable<System.DateTime> NGAYBD { get; set; }
        public Nullable<System.DateTime> NGAYKT { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> LANKY { get; set; }
        public string THOIHAN { get; set; }
        public Nullable<double> HESOLUONG { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }

        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
    }
}
