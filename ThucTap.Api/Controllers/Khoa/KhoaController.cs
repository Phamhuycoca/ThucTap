using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;

namespace ThucTap.Api.Controllers.Khoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaService _service;
        public KhoaController(IKhoaService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.getAll());
        }
        [HttpPost]
        public IActionResult Create(KhoaDto dto)
        {
            if (_service.Create(dto))
            {
                return Ok("Thêm mới thông tin thành công");
            }
            return BadRequest("Thông tin này đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(KhoaDto dto)
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
    }
}
