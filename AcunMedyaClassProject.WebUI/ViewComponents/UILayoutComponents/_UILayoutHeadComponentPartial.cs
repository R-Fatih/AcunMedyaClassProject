using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
