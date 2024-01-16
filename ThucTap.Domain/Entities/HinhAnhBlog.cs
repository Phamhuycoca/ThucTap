using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class HinhAnhBlog
    {
        public int HinhAnhBlogId { get; set; }
        public string? HinhAnhBlogUrl{ get; set; }
        public string? UrlApi {  get; set; }
        public int NoiDungBlogId { get; set; }
        public NoiDungBlog? noiDungBlog { get; set; }
    }
}
