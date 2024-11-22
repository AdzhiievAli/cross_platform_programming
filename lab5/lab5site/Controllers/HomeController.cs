using Microsoft.AspNetCore.Mvc;
using lab5site.Models;

namespace lab5site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                WelcomeMessage = "Лабораторна робота №5  запуск лабораторних робіт 1-3"
            };
            return View(model);
        }

        public IActionResult BasePage()
        {
            return View();
        }
    }
}
