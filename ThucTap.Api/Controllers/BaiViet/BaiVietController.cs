using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Api.Controllers.BaiViet
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietService _service;
        public BaiVietController(IBaiVietService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.getAll());
        }
        [HttpPost]
        public IActionResult Create([FromForm] BaiVietCreate model, IList<IFormFile> listFile)
        {
            try
            {
                DateTime now = DateTime.Now;
                model.NgayDang= DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                model.UrlApi = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                _service.CreateBaiViet(model, listFile);
                return Ok(new { model, listFile });
            }
            catch (Exception ex)
            {
                ex.ToString();
                return BadRequest("Không thể thực hiện thao tác");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] BaiVietUpdate model, IList<IFormFile> listFile)
        {
            try
            {
                DateTime now = DateTime.Now;
                BaiVietDto dto = new BaiVietDto()
                {
                    BaiVietId = model.BaiVietId,
                    NgayDang = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second),
                    NoiDung=model.NoiDung,
                    TieuDe=model.TieuDe,
                    TaiKhoanId=model.TaiKhoanId,
                    TrangThaiBaiViet = model.TrangThaiBaiViet
                };
                string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                _service.UpdateBaiViet(dto, listFile, model.HinhAnhBaiVietList, url);
                return Ok(new { model, listFile });
            }
            catch(Exception ex)
            {
                ex.ToString();
                return BadRequest("Không thể thực hiện thao tác");
            }
        }
    }
}
