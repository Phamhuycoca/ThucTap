using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class NoiDungBlog
    {
        public int NoiDungBlogId { get; set; }
        public string? NoiDung {  get; set; }
        public int BlogId { get; set; }
        public Blog? blog { get; set; }
        public ICollection<HinhAnhBlog>? hinhAnhBlogs { get; set; }
    }
}
