using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ThucTap.Api.Helper
{
    public class JWT
    {
        public static string Issuer { get; set; } = string.Empty;
        public static string Audience { get; set; } = string.Empty;
        public static SymmetricSecurityKey Key { get; set; }
        public static string KeyString { get; set; } = string.Empty;

        // Hàm tạo token
        public static string GenerateToken(int id, string role)
        {
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
        // Giải mã token để clam
        public static ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = Key,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                ClockSkew = TimeSpan.Zero // Không cho phép độ lệch thời gian
            }, out _);

            return claimsPrincipal;
        }
        //Lấy ID user từ token JWT
        public static string GetUserId(string token)
        {
            var claimsPrincipal = DecodeToken(token);

            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim != null)
            {
                return userIdClaim;
            }
            return "";

        }
        //Lấy Role user từ token JWT
        public static string GetUserRole(string token)
        {
            var claimsPrincipal = DecodeToken(token);

            var userRoleClaim = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;
            if (userRoleClaim != null)
            {
                return userRoleClaim;
            }
            return "";

        }
        // Mã hóa mật khẩu
        public static string hashPassword(string password)
        {
            if (password != null)
            {
                var saltBytes = Encoding.ASCII.GetBytes(KeyString);
                var passwordBytes = Encoding.ASCII.GetBytes(password);
                var hmac = new HMACSHA256(saltBytes);
                var hash = hmac.ComputeHash(passwordBytes);
                var hexHash = BitConverter.ToString(hash).Replace("-", "");
                return hexHash;
            }
            return "";

        }
        // Xác thực mật khẩu
        public static bool verifyPassword(string password, string hashedPassword)
        {
            if (password != null)
            {
                string passwordInput = hashPassword(password);
                if (passwordInput == hashedPassword)
                {
                    return true;
                }
                else
                { return false; }
            }
            return false;
        }
    }
}
