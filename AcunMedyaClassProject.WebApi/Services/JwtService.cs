using AcunMedyaClassProject.WebApi.Entities;
using AcunMedyaClassProject.WebApi.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcunMedyaClassProject.WebApi.Services
{
    public class JwtService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtTokenSettings _tokenSettings;

        public JwtService(UserManager<AppUser> userManager, IOptions<JwtTokenSettings> tokenSettings)
        {
            _userManager = userManager;
            _tokenSettings = tokenSettings.Value;
        }
        public async Task<string> GenerateToken(AppUser user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Key));
            var dateTimeNow = DateTime.UtcNow;
            var userRole = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,userRole.FirstOrDefault())
            };
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expireDate = dateTimeNow.AddHours(_tokenSettings.Expire);
            var token = new JwtSecurityToken(_tokenSettings.Issuer, _tokenSettings.Audience, claims, dateTimeNow, expireDate, credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
