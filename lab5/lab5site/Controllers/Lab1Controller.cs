using Microsoft.AspNetCore.Mvc;
using LabLibrary;

namespace lab5site.Controllers
{
    public class Lab1Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Run(string inputPath, string outputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath) || string.IsNullOrWhiteSpace(outputPath))
            {
                ViewData["Result"] = "вкажіть шляхи";
                return View("Index");
            }

            try
            {
                LabRunner.RunLab1(inputPath, outputPath);
                ViewData["Result"] = $"збережено по шляху {outputPath}";
            }
            catch (Exception ex)
            {
                ViewData["Result"] = $"помилка виконання {ex.Message}";
            }

            return View("Index");
        }
    }
}
