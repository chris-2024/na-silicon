using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models;

public class UserDetailsViewModel
{
    [Display(Name = "Firstname", Prompt = "Enter your name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Lastname", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number")]
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

    [Display(Name = "Addressline 1", Prompt = "Enter your address")]
    public string? Addressline1 { get; set; }

    [Display(Name = "Addressline 2", Prompt = "Enter your address")]
    public string? Addressline2 { get; set; }

    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [DataType(DataType.PostalCode)]
    public string? PostalCode { get; set; }

    [Display(Name = "City", Prompt = "Enter your city")]
    public string? City { get; set; }
}
