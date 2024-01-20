using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Application.Dto
{
    public class HinhAnhBaiVietDto
    {
        public int HinhAnhId { get; set; }
        public string? HinhAnhUrl { get; set; }
        public string? UrlApi { get; set; }
        public int BaiVietId { get; set; }
    }
}
