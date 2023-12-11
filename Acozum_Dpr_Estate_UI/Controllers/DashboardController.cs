using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
