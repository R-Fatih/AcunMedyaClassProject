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
        private readonly RoleManager<AppRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("registerTeacher")]
        public async Task<IActionResult> RegisterTeacher(RegisterDto dto)
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
                var roleExist = await _roleManager.RoleExistsAsync("Teacher");
                if (!roleExist)
                {
                    var role = new AppRole
                    {
                        Name = "Teacher"
                    };
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Teacher");
                    }
                }
                else
                    await _userManager.AddToRoleAsync(user, "Teacher");
                return Created("", user);
            }
            return BadRequest(result.Errors);
        }
        [HttpPost("registerStudent")]
        public async Task<IActionResult> RegisterStudent(RegisterDto dto)
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
                var roleExist = await _roleManager.RoleExistsAsync("Student");
                if (!roleExist)
                {
                    var role = new AppRole
                    {
                        Name = "Student"
                    };
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                    }
                }
                else
                    await _userManager.AddToRoleAsync(user, "Student");
                return Created("", user);
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users
                .Select(x => new { Id = x.Id, Name = x.FirstName + " " + x.LastName, Email = x.Email, Phone = x.PhoneNumber }).ToListAsync();
            return Ok(users);
        }
    }
}
