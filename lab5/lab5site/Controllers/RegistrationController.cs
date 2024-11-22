using Microsoft.AspNetCore.Mvc;
using lab5site.Models; 
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace lab5site.Controllers
{
    public class RegistrationController : Controller
    {
    public IActionResult Index()
{
    var model = new RegistrationModel();
    return View(model);  
}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                SaveUserToFile(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private void SaveUserToFile(RegistrationModel model)
        {
            string userData = $"Username: {model.Username}, FullName: {model.FullName}, Email: {model.Email}, Phone: {model.Phone}\n";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            System.IO.File.AppendAllText(filePath, userData);
        }
    }
}
