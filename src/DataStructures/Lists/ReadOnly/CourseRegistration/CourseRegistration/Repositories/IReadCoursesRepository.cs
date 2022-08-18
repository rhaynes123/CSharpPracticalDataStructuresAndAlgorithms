using System;
using CourseRegistration.Models;

namespace CourseRegistration.Repositories
{
    public interface IReadCoursesRepository
    {
        /// <summary>
        /// Gets all Courses with the change tracker turned off this must not be used in any methods attempt to change state!
        /// This is a good use case for a Readonly list because with the change tracker off in ef core its not able to proper modify the state of these items.
        /// Since the results aren't in the change tracker we are returning a types who name SPECIFACLLY implies the data should not be changed
        /// </summary>
        /// <returns>IRead only list of Course or an Empty list</returns>
        Task<IReadOnlyList<Course>> GetCoursesNoTrackingAsync();
    }
}

