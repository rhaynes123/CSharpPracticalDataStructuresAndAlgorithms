using System;
namespace CourseRegistration.Models
{
    public abstract class AuditableEntity
    {
        public AuditableEntity()
        {
        }
        public DateTime Created { get; } = DateTime.UtcNow;

        public DateTime? Deactivated { get; set; }

    }
}

