using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Application.Dto
{
    public class BaiVietDto
    {
        public int BaiVietId { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TrangThaiBaiViet { get; set; }
    }
}
