using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThucTap.Api.Helper;
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
        public readonly IEmailService _emailService;

        public TaiKhoanController(ITaiKhoanService service, IConfiguration configuration, IEmailService emailService)
        {
            _service = service;
            _configuration = configuration;
            _emailService = emailService;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginVM model)
        {
            HashMD5 md = new HashMD5();
            var user = _service.getAll().Find(x => x.Email == model.Email && x.MatKhau == md.GetMD5(model.MatKhau));
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
                HashMD5 md = new HashMD5();
                TaiKhoanDto dto = new TaiKhoanDto()
                {
                    Email = model.Email,
                    HoVaTen = model.HoVaTen,
                    MatKhau = md.GetMD5(model.MatKhau),
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



        [HttpPost("forgot")]
        public IActionResult Forgot([FromBody] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Chưa nhập thông tin");
                }
                else
                {
                    var existingUser = _service.getAll().FirstOrDefault(x => x.Email == email);
                    if (existingUser != null)
                    {
                        RandomPassword rd = new RandomPassword();
                        var code = rd.GenerateCode();
                        HashMD5 md = new HashMD5();

                        var dto = new TaiKhoanDto()
                        {
                            TaiKhoanId = existingUser.TaiKhoanId,
                            MatKhau = md.GetMD5(code),
                            Email = existingUser.Email,
                            DiaChi = existingUser.DiaChi,
                            HoVaTen = existingUser.HoVaTen,
                            HinhAnhUrl = existingUser.HinhAnhUrl,
                            Role = existingUser.Role,
                            GioiTinh=existingUser.GioiTinh,
                            KhoaId = existingUser.KhoaId,
                            urlApi = existingUser.urlApi

                        };

                        var registrationResult = _service.Update(dto);

                        if (registrationResult)
                        {
                            string subject = "Xác nhận quên mật khẩu tài khoản";
                            string message = $"<p>Đây là mật khẩu mới của bạn: {code}</p>";

                            _emailService.SendEmail(email, subject, message);

                            return Ok("Vui lòng kiểm tra email để lấy mật khẩu mới và đăng nhập.");
                        }
                        else
                        {
                            return BadRequest("Vui lòng thử lại sau.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
            return BadRequest("Đã xảy ra lỗi không xác định.");
        }

    }
}
