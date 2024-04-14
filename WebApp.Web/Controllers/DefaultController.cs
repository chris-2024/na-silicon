using Microsoft.AspNetCore.Mvc;

namespace WebApp.Web.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }

    [Route("/contact")]
    public IActionResult Contact()
    {
        return View();
    }

    [Route("/404")]
    public IActionResult NotAvailable()
    {
        return View();
    }
}
