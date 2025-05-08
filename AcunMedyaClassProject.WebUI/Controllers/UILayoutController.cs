using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
