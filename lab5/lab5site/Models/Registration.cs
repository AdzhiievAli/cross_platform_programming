using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace lab5site.Models
{
    public class RegistrationModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Ім'я користувача є обов'язковим")]
        [StringLength(50, ErrorMessage = "Ім'я користувача повинно містити не більше 50 символів")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "ФІО є обов'язковим")]
        [StringLength(500, ErrorMessage = "ФІО повинно містити не більше 500 символів")]
        public string FullName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "пароль є обов'язковим")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "пароль повинен містити від 8 до 16 символів")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "пароль повинен містити хоча б одну велику літеру, одну цифру та один спец символ")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Підтвердження паролю є обов'язковим")]
        [Compare("Password", ErrorMessage = "Пароль та підтвердження паролю не співпадають")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Телефон є обов'язковим")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Невірний формат номера телефону. Використовуйте формат +380xxxxxxxxx")]
        public string Phone { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Електронна адреса є обов'язковою")]
        [EmailAddress(ErrorMessage = "Невірний формат електронної адреси")]
        public string Email { get; set; }
    }
}
