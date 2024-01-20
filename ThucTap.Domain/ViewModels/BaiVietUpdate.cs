using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Entities;

namespace ThucTap.Domain.ViewModels
{
    public class BaiVietUpdate
    {
        public int BaiVietId { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TrangThaiBaiViet { get; set; }
        public string? UrlApi { get; set; }
        public int HinhAnhId { get; set; }
        public string? HinhAnhUrl { get; set; }
        public List<HinhAnhBaiViet>? HinhAnhBaiVietList { get; set; }
        public BaiVietUpdate()
        {
            HinhAnhBaiVietList = new List<HinhAnhBaiViet>();
        }
    }
}
