using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Lib.Contexts;
using WebApp.Lib.Entities;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers;

[Authorize]
public class AccountController(DataContext dbContext, UserManager<UserEntity> userManager) : Controller
{
    private readonly DataContext _context = dbContext;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null && user.Email != null)
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == user.AddressId);
                var viewModel = new UserDetailsViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Addressline1 = address?.Address1,
                    Addressline2 = address?.Address2,
                    PostalCode = address?.PostalCode,
                    City = address?.City
                };

                return View(viewModel);
            }
        }
        catch { }

        return RedirectToAction("Home", "Default");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDetails(UserDetailsViewModel model)
    {
        if (ModelState.IsValid && model != null)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.Phone;

                    if (user.AddressId != null)
                    {
                        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == user.AddressId);
                        if (address != null)
                        {
                            address.Address1 = model.Addressline1;
                            address.Address2 = model.Addressline2;
                            address.PostalCode = model.PostalCode;
                            address.City = model.City;
                        }
                    }
                    else 
                    {
                        var newAddress = new AddressEntity
                        {
                            Address1 = model.Addressline1,
                            Address2 = model.Addressline2,
                            PostalCode = model.PostalCode,
                            City = model.City
                        };

                        await _context.Addresses.AddAsync(newAddress);
                        user.Address = newAddress;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Default");
                }
            }
            catch { }
        }

        return View("Details");
    }

    [HttpGet]
    public IActionResult Security()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Security(UpdatePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Home", "Default");

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                    return RedirectToAction("Home", "Default");
            }
            catch { }
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAccount()
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == user.AddressId);
                if (address != null)
                {
                    _context.Addresses.Remove(address);
                }

                await _userManager.DeleteAsync(user);
            }
        }
        catch { }

        return RedirectToAction("SignOut", "Auth");
    }

    public IActionResult SavedCourses()
    {
        return View();
    }
}
