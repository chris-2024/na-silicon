using Microsoft.AspNetCore.Mvc;

namespace WebApp.Web.Controllers;

public class SiteSettingsController : Controller
{
    public IActionResult Theme(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(100)
        };

        Response.Cookies.Append("theme", mode, option);

        return Ok();
    }

    public IActionResult Consent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(100),
            HttpOnly = true,
            Secure = true
        };

        Response.Cookies.Append("consent", "true", option);

        return Ok();
    }
}
