using Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Services
{
    public class LoginService
    {
        public IUserService UserService;

        public IConfiguration Configuration;
        public LoginService(
            IUserService userService,
            IConfiguration configuration) {
            UserService = userService;
            Configuration = configuration;
        }

        public string Authenticate(LoginDTO dto)
        {
            var user = UserService.FindUserByEmail(dto.Email);

            if (user == null) return null;

            if(!user.Email.Equals(dto.Email) || !user.Password.Equals(dto.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(Configuration.GetSection("JWT_KEY").ToString());

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, dto.Email)
                }),

                Expires = DateTime.UtcNow.AddHours(3),

                SigningCredentials = new SigningCredentials (
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
