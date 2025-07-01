using Microsoft.AspNetCore.Mvc;

namespace check_users.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
