using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class Mon
    {
        public int MonId { get; set; }
        public string? TenMon {  get; set; }
        public int KhoaId { get; set; }
        public Khoa? khoa { get; set; }
    }
}
