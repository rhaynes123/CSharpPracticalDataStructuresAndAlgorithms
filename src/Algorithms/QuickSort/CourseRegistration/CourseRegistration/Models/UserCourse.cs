using System;
namespace CourseRegistration.Models
{
    public class UserCourse : AuditableEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}

