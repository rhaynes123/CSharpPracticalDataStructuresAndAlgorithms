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
        /// <summary>
        /// Returns a read only collection of the courses in descenging order by id.
        /// This is a great example of a "stable" quick sort as that is the underlying sort algorithim of the OrderBy
        /// </summary>
        /// <returns></returns>
        // https://stackoverflow.com/questions/5958769/what-sorting-algorithm-does-the-net-framework-implement
        // https://stackoverflow.com/questions/1832684/c-sharp-sort-and-orderby-comparison
        // https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderbydescending?view=net-6.0
        // https://www.tutorialsteacher.com/linq/linq-sorting-operators-orderby-orderbydescending
        public async Task<IReadOnlyCollection<Course>> GetCoursesNoTrackingAsync()
        {
            if (_dbContext.Courses is null)
            {
                return ImmutableList<Course>.Empty;
            }
            return await _dbContext.Courses
                .OrderByDescending(course => course.Id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

