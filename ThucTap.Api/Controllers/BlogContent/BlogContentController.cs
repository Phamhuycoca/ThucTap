using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;
using ThucTap.Domain.Entities;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Api.Controllers.BlogContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogContentController : ControllerBase
    {
        private readonly INoiDungBlogService _service;
        private IMapper _mapper;

        public BlogContentController(INoiDungBlogService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.getAll());
        }
        [HttpPost]
        public IActionResult Create(NoiDungBlogDto dto)
        {
            if (_service.Create(dto))
            {
                return Ok("Thêm mới thông tin thành công");
            }
            return BadRequest("Thông tin này đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(NoiDungBlogDto dto)
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
        [HttpPost("CreateContent")]
        public IActionResult CreateContent([FromForm] BlogContentCreate model,IList<IFormFile> listFile)
        {
            try
            {
                model.UrlApi =$"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                _service.CreateBlogContent(model, listFile);
                return Ok(new { model, listFile });
            }
            catch (Exception ex) 
            {
                ex.ToString();
                return BadRequest("Không thể thực hiện thao tác");
            }
        }
        [HttpPut("UpdateContent/{id}")]
        public IActionResult UpdateContent([FromForm] BlogContentUpdate model,IList<IFormFile> listFile)
        {
            NoiDungBlogDto dto=new NoiDungBlogDto()
            {
                BlogId = model.BlogId,
                NoiDung=model.NoiDung,
                NoiDungBlogId=model.NoiDungBlogId,
            };
            string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            _service.UpdateBlogContent(dto, listFile,model.HinhAnhBlogList,url);
                return Ok(new {model,listFile});
        }
       [HttpGet("getByIdBlog/{id}")] 
        public IActionResult getByIdBlog(int id)
        {
            return Ok(_service.getByIdBlog(id));
        }
    }
}
