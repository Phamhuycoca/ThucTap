using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;

namespace ThucTap.Api.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _service;
        public BlogController(IBlogService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.getAll());
        }
        [HttpPost]
        public IActionResult Create(BlogDto dto)
        {
            dto.NgayDang = DateTime.Today;
            if (_service.Create(dto))
            {
                return Ok("Thêm mới thông tin thành công");
            }
            return BadRequest("Thông tin này đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(BlogDto dto)
        {
            if (_service.Update(dto))
            {
                return Ok("Cập nhật thông tin thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return Ok("Xóa thông tin thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpGet("GetNew")]
        public IActionResult GetNew()
        {
            return Ok(_service.GetNew());
        }
        [HttpGet("getBlogGanDay")]
        public IActionResult getBlogGanDay()
        {
            return Ok(_service.getBlogGanDay());
        }
        [HttpGet("getAllByIdKhoa/{id}")]
        public IActionResult getAllByIdKhoa(int id)
        {
            return Ok(_service.getAllByIdKhoa(id));
        }
    }
}
