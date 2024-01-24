using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.ViewModels
{
    public class BaiVietList
    {
        public int BaiVietId { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TrangThaiBaiViet { get; set; }
        public string? HoVaTen { get; set; }
        public string? HinhAnhUrl { get; set; }
        public string? urlApi { get; set; }

    }
}
