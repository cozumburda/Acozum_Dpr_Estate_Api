using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_UI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
