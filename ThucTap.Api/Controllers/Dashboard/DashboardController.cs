using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ThucTap.Application.IService;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Api.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IBaiVietService _baiVietService;
        public DashboardController(IBaiVietService baiVietService)
        {
            _baiVietService = baiVietService;
        }
        [HttpGet("ThongKeTheoTuan")]
        public IActionResult ThongKeTheoTuan()
        {
            var groupedResult = _baiVietService
      .getAll()
      .Where(bv => bv.NgayDang.HasValue && bv.NgayDang.Value.Year == DateTime.Now.Year
                    && bv.NgayDang.Value.Month == DateTime.Now.Month)
      .GroupBy(bv => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(bv.NgayDang.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
      .Select(group => new
      {
          Week = group.Key,
          SoLuongBaiViet = group.Count(),
      })
      .OrderBy(item => item.Week)
      .ToList();
            var thongKe = new ThongKeTheoTuan();
            foreach (var item in groupedResult)
            {
                switch (item.Week)
                {
                    case 1:
                        thongKe.TuanMot = item.SoLuongBaiViet;
                        break;
                    case 2:
                        thongKe.TuanHai = item.SoLuongBaiViet;
                        break;
                    case 3:
                        thongKe.TuanBa = item.SoLuongBaiViet;
                        break;
                    case 4:
                        thongKe.TuanBon = item.SoLuongBaiViet;
                        break;
                }
            }
            return Ok(thongKe);
        }
        [HttpGet("ThongKeBaiViet")]
        public IActionResult ThongKeBaiViet()
        {
            var result = new ThongKeBaiViet()
            {
                BaiVietChuaDuyet = _baiVietService.getAllBaiViet().Count(x => x.TrangThaiBaiViet == 0),
                TongBaiViet=_baiVietService.getAll().Count()
            };
            return Ok(result);
        }
        
    }
}
