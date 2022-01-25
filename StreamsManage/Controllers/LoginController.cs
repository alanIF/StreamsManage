using Microsoft.AspNetCore.Mvc;

namespace StreamsManage.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult store()
        {
            return View();
        }
    }
}
