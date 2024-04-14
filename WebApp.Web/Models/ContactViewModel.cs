using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models;

public class ContactViewModel
{
    [Display(Name = "Full name", Prompt = "Full name")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Display(Name = "Service", Prompt = "Choose the service you are interested in")]
    public string Service { get; set; } = null!;

    [Display(Name = "Message", Prompt = "Enter your message here")]
    public string Message { get; set; } = null!;
}
