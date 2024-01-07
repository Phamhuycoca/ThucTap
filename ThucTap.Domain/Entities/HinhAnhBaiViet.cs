using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class HinhAnhBaiViet
    {
        public int HinhAnhId {get; set;}
        public string? HinhAnhUrl { get; set;}
        public int BaiVietId { get; set;}
        public BaiViet? baiViet { get; set;}
    }
}
