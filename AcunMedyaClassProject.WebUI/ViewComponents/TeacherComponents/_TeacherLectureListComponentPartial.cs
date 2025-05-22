using AcunMedyaClassProject.Dtos.LectureDtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcunMedyaClassProject.WebUI.ViewComponents.TeacherComponents
{
    public class _TeacherLectureListComponentPartial:ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var userId = UserClaimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await client.GetFromJsonAsync<List<ResultLectureDto>>("https://localhost:7090/api/Lectures/GetLectureByLecturer?lecturerId=" + userId);
            return View(result);
        }
    }
}
