using WebApp.Lib.Entities;

namespace WebApp.Web.Models;

public class CoursesViewModel
{
    public IEnumerable<CategoryEntity>? Categories { get; set; }
    public IEnumerable<CourseEntity>? Courses { get; set; }
    public Pagination? Pagination { get; set; }
}
