using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models;

public class SignInViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email", Prompt = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password", Prompt = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
