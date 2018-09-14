using Microsoft.AspNetCore.Mvc;

namespace KedaiRuncitWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}