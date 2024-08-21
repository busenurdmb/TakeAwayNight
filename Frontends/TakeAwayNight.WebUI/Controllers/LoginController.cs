using Microsoft.AspNetCore.Mvc;

namespace TakeAwayNight.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
