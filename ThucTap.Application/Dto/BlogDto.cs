using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Application.Dto
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string? TieuDe { get; set; }
        public DateTime? NgayDang { get; set; }
        public int TaiKhoanId { get; set; }
        public int KhoaId { get; set; }
    }
}
