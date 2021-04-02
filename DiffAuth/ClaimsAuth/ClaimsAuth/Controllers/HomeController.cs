using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuth.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Policy = "OnlyForLondon")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "OnlyForMicrosoft")]
        public IActionResult About()
        {
            return Content("Only for Microsoft employees");
        }
    }
}
