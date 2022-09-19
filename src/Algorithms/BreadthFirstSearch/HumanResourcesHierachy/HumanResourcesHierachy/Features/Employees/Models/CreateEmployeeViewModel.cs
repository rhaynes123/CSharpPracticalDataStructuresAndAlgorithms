using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HumanResourcesHierachy.Features.Employees.Models.Enums;
namespace HumanResourcesHierachy.Features.Employees.Models
{
    public class CreateEmployeeViewModel
    {
        public CreateEmployeeViewModel()
        {
        }
        [Required]
        public Guid EmployeeNumber { get; set; } = Guid.NewGuid();
        [Required, StringLength(100),]
        public string? FirstName { get; set; }
        public Role Role { get; set; }
        [Required]
        public string? LastName { get; set; }
        [DisplayName("Manager")]
        public int? ManagerId { get; set; } = null!;
        //public Employee Manager { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

