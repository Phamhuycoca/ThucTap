using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class CommentBlog
    {
        public int CommentBlogId { get; set; }
        public int TaiKhoanId {  get; set; }
        public int BlogId { get; set; }
        public string? NoiDungComment { get; set; }
        public DateTime? NgayComment {  get; set; }
        public TaiKhoan? taiKhoan { get; set; }
        public Blog? blog { get; set; }
    }
}
