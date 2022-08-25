using System.Collections.Immutable;
using CourseRegistration.Models;
using CourseRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseRegistration.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IReadCoursesRepository _coursesRepository;
    public IndexModel(ILogger<IndexModel> logger, IReadCoursesRepository repository)
    {
        _logger = logger;
        _coursesRepository = repository;
    }
    [BindProperty]
    public IReadOnlyCollection<Course> Courses { get; set; } = ImmutableList<Course>.Empty;

    public async Task<IActionResult> OnGet()
    {
        IReadOnlyCollection<Course> courses = await _coursesRepository.GetCoursesNoTrackingAsync();
        if(courses is null || !courses.Any())
        {
            _logger.LogError("Courses were empty");
            return Page();
        }

        Courses = courses;
        return Page();

    }
}

