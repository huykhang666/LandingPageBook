using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterDto dto)
        {
            // Kiểm tra username đã tồn tại chưa
            if (await _accountRepository.IsUsernameTakenAsync(dto.Username))
            {
                return ApiResponse<AuthResponseDto>.Fail("Tên đăng nhập đã được sử dụng. Vui lòng chọn tên khác.");
            }

            // Tạo tài khoản mới với vai trò mặc định là User
            var account = new Account
            {
                Username = dto.Username.Trim().ToLower(),
                Password = dto.Password, // Lưu ý: trong thực tế nên hash bằng BCrypt hoặc PBKDF2
                FullName = dto.FullName.Trim(),
                Role = "User"
            };

            await _accountRepository.AddAsync(account);
            await _accountRepository.SaveAsync();

            var token = GenerateJwtToken(account);

            var response = new AuthResponseDto
            {
                AccountId = account.AccountId,
                Username = account.Username,
                FullName = account.FullName,
                Role = account.Role,
                Token = token
            };

            return ApiResponse<AuthResponseDto>.Ok(response, "Đăng ký tài khoản thành công!");
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto dto)
        {
            var account = await _accountRepository.GetByUsernameAsync(dto.Username);
            if (account == null || account.Password != dto.Password)
            {
                return ApiResponse<AuthResponseDto>.Fail("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            var token = GenerateJwtToken(account);

            var response = new AuthResponseDto
            {
                AccountId = account.AccountId,
                Username = account.Username,
                FullName = account.FullName,
                Role = account.Role,
                Token = token
            };

            return ApiResponse<AuthResponseDto>.Ok(response, "Đăng nhập thành công!");
        }

        public async Task<ApiResponse<AuthResponseDto>> GetProfileAsync(string username)
        {
            var account = await _accountRepository.GetByUsernameAsync(username);
            if (account == null)
            {
                return ApiResponse<AuthResponseDto>.Fail("Không tìm thấy người dùng.");
            }

            var response = new AuthResponseDto
            {
                AccountId = account.AccountId,
                Username = account.Username,
                FullName = account.FullName,
                Role = account.Role,
                Token = string.Empty
            };

            return ApiResponse<AuthResponseDto>.Ok(response);
        }

        private string GenerateJwtToken(Account account)
        {
            var keyString = _configuration["Jwt:Key"] ?? "SecretKey_LandingPage_Sach_PauloCoelho_2026_Secure_Key_LongEnough";
            var issuer = _configuration["Jwt:Issuer"] ?? "LandingPageApi";
            var audience = _configuration["Jwt:Audience"] ?? "LandingPageClients";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                new Claim(ClaimTypes.Name, account.Username),
                new Claim("FullName", account.FullName),
                new Claim(ClaimTypes.Role, account.Role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
