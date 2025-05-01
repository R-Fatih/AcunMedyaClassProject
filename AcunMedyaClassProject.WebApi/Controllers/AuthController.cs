using AcunMedyaClassProject.WebApi.Dtos;
using AcunMedyaClassProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AcunMedyaClassProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return Created("", user);
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users
                .Select(x=>new {Id=x.Id,Name=x.FirstName+" "+x.LastName,Email=x.Email,Phone=x.PhoneNumber}).ToListAsync();
            return Ok(users);
        }
    }
}
