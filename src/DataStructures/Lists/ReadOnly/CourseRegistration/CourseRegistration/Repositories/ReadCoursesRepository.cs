using System;
using System.Collections.Immutable;
using CourseRegistration.Data;
using CourseRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration.Repositories
{
    public class ReadCoursesRepository: IReadCoursesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReadCoursesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Course>> GetCoursesNoTrackingAsync()
        {
            if (_dbContext.Courses is null)
            {
                return ImmutableList<Course>.Empty;
            }
            return await _dbContext.Courses.AsNoTracking().ToListAsync();
        }
    }
}

