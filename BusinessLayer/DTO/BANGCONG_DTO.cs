using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class BANGCONG_DTO
    {
        public int MABC { get; set; }
        public Nullable<int> SONGAYCONG { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> IDLC { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> DELETED_BY { get; set; }

        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
        public virtual tb_LOAICONG tb_LOAICONG { get; set; }
    }
}
