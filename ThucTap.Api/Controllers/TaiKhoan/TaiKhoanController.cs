using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThucTap.Application.Dto;
using ThucTap.Application.Helper;
using ThucTap.Application.IService;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Api.Controllers.TaiKhoan
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanService _service;
        private readonly IConfiguration _configuration;
        public TaiKhoanController(ITaiKhoanService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginVM model)
        {
            var user = _service.getAll().Find(x => x.Email == model.Email && x.MatKhau == model.MatKhau);
            // var user = _nguoiDungService.GetAll().Find(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,string.Join(",",user.Role)),
                    new Claim(ClaimTypes.NameIdentifier,user.TaiKhoanId.ToString()),
                };
                var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signingCredential,
                        claims: claims
                    );
                return Ok(new
                {
                    message = "Đăng nhập thành công",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    role = user.Role,
                    Id = user.TaiKhoanId,
                });
            }
            return BadRequest("Tài khoản hoặc mật khẩu không chính xác");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterVM model)
        {
            var check = _service.getAll().Where(x => x.Email == model.Email).FirstOrDefault();
            if (check != null)
            {
                return BadRequest("Email đã tồn tại");
            }
            else
            {
                TaiKhoanDto dto = new TaiKhoanDto()
                {
                    Email = model.Email,
                    HoVaTen = model.HoVaTen,
                    MatKhau = model.MatKhau,
                    Role = "Người dùng"

                };
                _service.Create(dto);
                return Ok("Đăng ký tài khoản thành công");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromForm] TaiKhoanViewModel model)
        {
            TaiKhoanDto dto = new TaiKhoanDto();
            dto.DiaChi = model.DiaChi;
            dto.Email = model.Email;
            dto.GioiTinh = model.GioiTinh;
            dto.HoVaTen = model.HoVaTen;
            dto.KhoaId = model.KhoaId;
            dto.Role = model.Role;
            dto.TaiKhoanId = model.TaiKhoanId;
            dto.MatKhau = model.MatKhau;
            if (model.HinhAnhUrl != null)
            {
                dto.HinhAnhUrl = ServiceImage.createImage(model.HinhAnhUrl);
            }
            else
            {
                dto.HinhAnhUrl = _service.GetById(model.TaiKhoanId).HinhAnhUrl;
            }
            dto.urlApi= $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            if(_service.Update(dto))
            {
                return Ok("Cập nhật thông tin thành công");
            }
            return BadRequest("Không thể thao tác");
        }
    }
}
