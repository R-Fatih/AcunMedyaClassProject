using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebUI.ViewComponents.TeacherComponents
{
    public class _TeacherSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
