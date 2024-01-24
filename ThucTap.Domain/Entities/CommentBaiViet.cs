using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class CommentBaiViet
    {
        public int CommentBaiVietId { get; set; }
        public int TaiKhoanId { get; set; }
        public int BaiVietId { get; set; }
        public string? NoiDungComment { get; set; }
        public DateTime? NgayComment { get; set; }
        public TaiKhoan? taiKhoan { get; set; }
        public BaiViet? baiViet { get; set; }
    }
}
