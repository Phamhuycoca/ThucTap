using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.ViewModels
{
    public class NotiTaiKhoan
    {
        public int NotiId { get; set; }
        public int? BaiVietId { get; set; }
        public int? BlogId { get; set; }
        public DateTime? NotiDatetime { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TaiKhoanComment { get; set; }
        public int? TrangThai { get; set; }
        public string? HoVaTen { get; set; }
        public string? HinhAnhUrl { get; set; }
        public string? urlApi { get; set; }
    }
}
