using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Utilities;

public class CheckboxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;

    }
}
