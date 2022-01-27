using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamsManage.Context;
using StreamsManage.Models;
using System.Security.Claims;

namespace StreamsManage.Controllers
{
    // paginas que nao precisa está  logado
    [AllowAnonymous]
     public class LoginController : Controller
    {
        private readonly BD _context;
        public LoginController(BD context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {

                return RedirectToAction("Index", "Home");

            }
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
        [HttpPost]
        public async Task<IActionResult> Logar(string Email, string Password) {
            var user =  _context.Users.Where(u => u.Email==Email && u.Password==Password).ToList();
            if (user.Any()) {
                int usuarioId  = user[0].Id;
                string email = user[0].Email;
                List<Claim> direitosAcesso = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                    new Claim(ClaimTypes.Name,email)
                };
                var identity = new ClaimsIdentity(direitosAcesso,"Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity});
                await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties { 
                    IsPersistent=false,
                    ExpiresUtc = DateTime.Now.AddHours(1)
                
                });
                return RedirectToAction("Index", "Home");

                return Json(new { Msg = "Usuario logado com sucesso" });

            }

            return Json(new {Msg="Usuario nao logado com sucesso"});
        }
        public async Task<IActionResult> Logout() {
            if (User.Identity.IsAuthenticated) { 
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
