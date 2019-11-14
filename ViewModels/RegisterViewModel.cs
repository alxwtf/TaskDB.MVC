using System.ComponentModel.DataAnnotations;

namespace TaskDB.MVC
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage= "Пароли не совпадают")]
        public string ConfirmPassword { get; set;}
    }
}