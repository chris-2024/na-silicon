using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Lib.Contexts;
using WebApp.Lib.Entities;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers;

[Authorize]
public class CourseController(DataContext dbContext) : Controller
{
    private readonly DataContext _context = dbContext;

    [HttpGet]
    [Route("/courses")]
    public async Task<IActionResult> Courses(string? category, int? pageNumber, int pageSize = 6)
    {
        var viewModel = new CoursesViewModel()
        {
            Courses = [],
            Categories = []
        };

        try
        {
            category ??= "all";

            viewModel.Courses = await _context.Courses.Include(c => c.Category).ToListAsync();
            if (!viewModel.Courses.Any())
                return RedirectToAction("Home", "Default");

            viewModel.Categories = await _context.Categories.ToListAsync();

            int courseCount = viewModel.Courses.Count();
            var pages = (int)Math.Ceiling(courseCount / (double)pageSize);

            viewModel.Pagination = new() 
            { 
                CurrentPage = pageNumber ?? 1, 
                PageTotal = pages,
                PageSize = pageSize,
                TotalCount = courseCount
            };
        }
        catch { }
        return View(viewModel); 
    }

    [HttpGet]
    [Route("/courses/{id}")]
    public async Task<IActionResult> CourseDetails(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return RedirectToAction("NotAvailable", "Default");
        }

        var course = await _context.Courses
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null)
        {
            return RedirectToAction("NotAvailable", "Default");
        }

        return View(course);
    }
}
