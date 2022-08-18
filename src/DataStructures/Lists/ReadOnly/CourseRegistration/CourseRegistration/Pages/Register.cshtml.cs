using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseRegistration.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseRegistration.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public RegisterModel(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task OnGet(int id)
        {
            await _dbContext.UserCourses.AddAsync(new Models.UserCourse
            {
                CourseId = id,
                UserId = Guid.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier))
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
