using Microsoft.AspNetCore.Mvc;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("Admin/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
