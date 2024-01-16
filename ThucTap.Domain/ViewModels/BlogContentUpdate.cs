using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Entities;
namespace ThucTap.Domain.ViewModels
{
    public class BlogContentUpdate
    {
        public int NoiDungBlogId { get; set; }
        public string? NoiDung { get; set; }
        public int BlogId { get; set; }
        public int HinhAnhBlogId { get; set; }
        public string? UrlApi { get; set; }
        public string? HinhAnhBlogUrl { get; set; }
        public List<HinhAnhBlog>? HinhAnhBlogList { get; set; }
        public BlogContentUpdate()
        {
            HinhAnhBlogList=new List<HinhAnhBlog>();
        }
    }
}
