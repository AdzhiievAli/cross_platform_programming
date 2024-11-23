using Microsoft.AspNetCore.Mvc;
using lab5site.Models;
using System.IO;

namespace lab5site.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            if (System.IO.File.Exists(filePath))
            {
                string[] userData = System.IO.File.ReadAllLines(filePath).LastOrDefault()?.Split(", ");
                if (userData != null)
                {
                    var model = new ProfileModel
                    {
                        Username = GetValue(userData, "Username"),
                        FullName = GetValue(userData, "FullName"),
                        Email = GetValue(userData, "Email"),
                        Phone = GetValue(userData, "Phone")
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Registration");
        }

        private string GetValue(string[] data, string key)
        {
            return data.FirstOrDefault(x => x.StartsWith($"{key}:"))?.Split(": ")[1] ?? string.Empty;
        }
    }
}
