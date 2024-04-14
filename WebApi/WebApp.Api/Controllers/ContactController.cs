using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(ApiContext context) : Controller
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Contact(Contact form)
    {
        if (ModelState.IsValid)
        {
            var entity = ContactFactory.Create(form);
            _context.Contacts.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }

}
