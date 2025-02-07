using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Security.Claims;

namespace ArticleChat.Controllers
{
    public class AuthController(ArticleChatDbContext context) : Controller
    {
        private readonly ArticleChatDbContext _context = context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public async Task<IActionResult> Login(string nickname, string password)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Nickname == nickname && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.Nickname!),
                    new(ClaimTypes.Role, user.Role!.UserRole.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "UserIdentity");
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                Logger.Info($"User {nickname} authorized.");

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверное имя пользователя или пароль");
            Logger.Info($"User {nickname} is not authorized.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
