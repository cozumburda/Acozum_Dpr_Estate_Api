using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
