using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.ViewModels
{
    public class TaiKhoanViewModel
    {
        public int TaiKhoanId { get; set; }
        public string? HoVaTen { get; set; }
        public IFormFile? HinhAnhUrl { get; set; }
        public string? urlApi { get; set; }
        public bool? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public int? KhoaId { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string Role { get; set; }
    }
}
