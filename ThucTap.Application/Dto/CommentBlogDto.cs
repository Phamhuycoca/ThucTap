using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Application.Dto
{
    public class CommentBlogDto
    {
        public int CommentBlogId { get; set; }
        public int TaiKhoanId { get; set; }
        public int BlogId { get; set; }
        public string? NoiDungComment { get; set; }
        public DateTime? NgayComment { get; set; }
    }
}
