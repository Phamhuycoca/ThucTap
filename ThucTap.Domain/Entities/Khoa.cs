using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class Khoa
    {
        public int KhoaId { get; set; }
        public string? TenKhoa {  get; set; }
        public ICollection<Mon>? mons { get; set; }
        public ICollection<TaiKhoan>? taiKhoans { get; set; }
    }
}
