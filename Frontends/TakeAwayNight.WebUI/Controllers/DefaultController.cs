using Microsoft.AspNetCore.Mvc;

namespace TakeAwayNight.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
