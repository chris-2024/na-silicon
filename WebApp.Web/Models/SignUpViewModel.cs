﻿using System.ComponentModel.DataAnnotations;
using WebApp.Web.Utilities;

namespace WebApp.Web.Models;

public class SignUpViewModel
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Enter a valid first name")]
    [MinLength(2, ErrorMessage = "Enter a valid first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Enter a valid last name")]
    [MinLength(2, ErrorMessage = "Enter a valid last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your Email address")]
    [Required(ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "Enter a valid password")]
    [MinLength(8, ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Password don't match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [CheckboxRequired]
    [Display(Name = "I agree to the Terms & Conditions.", Prompt = "I accept the terms and conditions")]
    public bool TermsAndConditions { get; set; }
}
