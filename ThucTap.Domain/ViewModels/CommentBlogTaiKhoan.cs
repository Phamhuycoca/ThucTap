using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.ViewModels
{
    public class CommentBlogTaiKhoan
    {
        public int CommentBlogId { get; set; }
        public int TaiKhoanId { get; set; }
        public int BlogId { get; set; }
        public string? NoiDungComment { get; set; }
        public DateTime? NgayComment { get; set; }
        public string? HoVaTen {  get; set;}
        public string? HinhAnhUrl { get; set;}
    }
}
