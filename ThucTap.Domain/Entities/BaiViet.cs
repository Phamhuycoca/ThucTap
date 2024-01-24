using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Entities
{
    public class BaiViet
    {
        public int BaiVietId { get; set; }
        public string? TieuDe {  get; set; }
        public string? NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public int? TaiKhoanId { get; set; }
        public int? TrangThaiBaiViet {  get; set; }
        public TaiKhoan? taiKhoan { get; set;}
        public ICollection<HinhAnhBaiViet>? hinhAnh { get; set; }
        public ICollection<CommentBaiViet>? commentBaiViets { get; set; }
    }
}
