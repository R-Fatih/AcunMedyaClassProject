using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebUI.Controllers
{
    
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
