using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Course: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}

