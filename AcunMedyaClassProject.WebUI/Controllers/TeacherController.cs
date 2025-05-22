using AcunMedyaClassProject.Dtos.LectureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcunMedyaClassProject.WebUI.Controllers
{
    [Authorize(Roles ="Teacher")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecture(CreateLectureDto dto)
        {
            var userId=User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            dto.LecturerId = userId;
            var client = new HttpClient();
            var result = await client.PostAsJsonAsync("https://localhost:7090/api/Lectures", dto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return View();
            }
        }
    }
}
