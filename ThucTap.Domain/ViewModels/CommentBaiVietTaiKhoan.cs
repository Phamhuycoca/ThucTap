using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.ViewModels
{
    public class CommentBaiVietTaiKhoan
    {
        public int CommentBaiVietId { get; set; }
        public int TaiKhoanId { get; set; }
        public int BaiVietId { get; set; }
        public string? NoiDungComment { get; set; }
        public DateTime? NgayComment { get; set; }
        public string? HoVaTen { get; set; }
        public string? HinhAnhUrl { get; set; }
    }
}
