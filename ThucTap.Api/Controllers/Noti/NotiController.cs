using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;

namespace ThucTap.Api.Controllers.Noti
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotiController : ControllerBase
    {
        private readonly INotiService _service;
        public NotiController(INotiService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.getAll());
        }
        [HttpPut("{id}")]
        public IActionResult Put(NotiDto dto)
        {
            dto.TrangThai = 1;
            if(_service.Update(dto))
            {
                return Ok("");
            }
            return BadRequest("Không thể thao tác");
        }
        [HttpGet("{id}")]
        public IActionResult getAllById(int id)
        {
            return Ok(_service.getAllById(id));
        }
        [HttpPut("SeenNoti/{id}")]
        public IActionResult SeenNoti(int id)
        {
            return Ok(_service.SeenNoti(id));
        }
    }
}
