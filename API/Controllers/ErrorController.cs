using ArticleChat.Models.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace API.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        // Страница доступа запрещена
        public IActionResult AccessDenied()
        {
            Logger.Info($"Access is denied.");
            return View();
        }

        // Страница ресурса не найдена
        public new IActionResult NotFound()
        {
            Logger.Info($"Page is not found.");
            return View();
        }

        // Страница общего сообщения об ошибке
        public IActionResult GeneralError()
        {
            Logger.Info($"General Error.");
            return View();
        }
    }
}
