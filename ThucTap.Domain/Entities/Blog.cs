using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? TieuDe {  get; set; }
        public DateTime? NgayDang { get; set; }
        public int TaiKhoanId { get; set; }
        public int KhoaId { get; set; }
        public TaiKhoan? taiKhoan {  get; set; }
        public Khoa? khoa { get; set; }
        public ICollection<NoiDungBlog>? noiDungBlogs { get;set; }
        public ICollection<CommentBlog>? commentBlogs { get; set;}
    }
}
