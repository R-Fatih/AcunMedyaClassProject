using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
