using AcunMedyaClassProject.WebUI.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcunMedyaClassProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            var client = new HttpClient();
           var result=await client.PostAsJsonAsync("https://localhost:7090/api/Auth/login", dto);
            if (result.IsSuccessStatusCode)
            {
                var stringToken = await result.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<LoginResponseDto>(stringToken);
                if (token != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token.Token);
                    var claims = jwtToken.Claims.ToList();
                    claims.Add(new System.Security.Claims.Claim("Token", token.Token));
                    var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1)
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
