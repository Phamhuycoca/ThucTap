using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class Noti
    {
        public int NotiId { get; set; }
        public int? BaiVietId { get; set; }
        public int? BlogId { get; set; }
        public DateTime? NotiDatetime { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TaiKhoanComment {  get; set; }
        public int? TrangThai {  get; set; }
        public BaiViet? baiViet { get; set; }
        public Blog? blog { get; set; }
        public TaiKhoan? taiKhoan { get; set; }

    }
}
