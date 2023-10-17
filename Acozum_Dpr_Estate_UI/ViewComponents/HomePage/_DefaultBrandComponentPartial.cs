using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultBrandComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
