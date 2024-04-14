using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiContext context) : Controller
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(Subscribe sub)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Subscribers.AnyAsync(x => x.Email == sub.Email))
                return Conflict();

            try
            {
                _context.Subscribers.Add(SubscribeFactory.Create(sub));
                await _context.SaveChangesAsync();
                return Created("", null);
            }
            catch { }
            return Problem();
        }

        return BadRequest();
    }
}
