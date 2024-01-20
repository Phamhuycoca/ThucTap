using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;

namespace ThucTap.Api.Controllers.CommentBlog
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentBlogController : ControllerBase
    {
        private readonly ICommentBlogService _service;
        public CommentBlogController(ICommentBlogService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.getAll());
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(CommentBlogDto dto)
        {
            DateTime now = DateTime.Now;
            dto.NgayComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            if (_service.Create(dto))
            {
                return Ok("Bình luận thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(CommentBlogDto dto)
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpGet("GetAllCommentByBlogId")]
        public IActionResult GetAllCommentByBlogId()
        {
            return Ok(_service.getAllByBlogId());
        }
    }
}
