using Microsoft.AspNetCore.Mvc;
using StreamsManage.Context;
using StreamsManage.Models;

namespace StreamsManage.Controllers
{
    public class LoginController : Controller
    {
        private readonly BD _context;
        public LoginController(BD context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> store([Bind("Id,Name,Email,Password")] UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
       
    }
}
