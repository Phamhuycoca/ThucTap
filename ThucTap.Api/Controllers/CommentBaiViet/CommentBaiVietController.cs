using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;

namespace ThucTap.Api.Controllers.CommentBaiViet
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentBaiVietController : ControllerBase
    {
        private readonly ICommentBaiVietService _service;
        private readonly INotiService _otiService;
        private readonly IBaiVietService _baiVietService;
        public CommentBaiVietController(ICommentBaiVietService service, INotiService otiService, IBaiVietService baiVietService)
        {
            _service = service;
            _otiService = otiService;
            _baiVietService = baiVietService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.getAllById());
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(CommentBaiVietDto dto)
         {
            DateTime now = DateTime.Now;
            dto.NgayComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            if (_service.Create(dto))
            {
                var idTaiKhoan=_baiVietService.GetById(dto.BaiVietId).TaiKhoanId;
                NotiDto noti = new NotiDto()
                {
                    BaiVietId = dto.BaiVietId,
                    BlogId = null,
                    NotiDatetime = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second),
                    TaiKhoanId = idTaiKhoan,
                    TrangThai = 0,
                    TaiKhoanComment=dto.TaiKhoanId
                };
                if (_otiService.Create(noti))
                {
                    return Ok("Bình luận thành công");
                }

            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(CommentBaiVietDto dto)
        {
            DateTime now = DateTime.Now;
            dto.NgayComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            if (_service.Update(dto))
            {
                return Ok("Cập nhật bình luận thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return Ok("Xóa bình luận thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
    }
}
