using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChat.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        // Страница доступа запрещена
        public IActionResult AccessDenied()
        {
            return View();
        }

        // Страница ресурса не найдено
        public IActionResult NotFound()
        {
            return View();
        }

        // Страница общего сообщения об ошибке
        public IActionResult GeneralError()
        {
            return View();
        }
    }
}
