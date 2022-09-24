using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResourcesHierachy.Features.Employees.Models
{
    public sealed class EmployeeRole
    {
        public EmployeeRole()
        {
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public Employee Employee { get; set; } = default!;
        [Required]
        public Enums.Role Role { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? DeactivatedDateTime { get; set; }
    }
}

