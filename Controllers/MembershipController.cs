using Microsoft.AspNetCore.Mvc;

namespace Equinox.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult List(string id = "All")
        {
            return Content($"Main Area, Membership Controller, List Action, id: {id}");
        }
    }
}
