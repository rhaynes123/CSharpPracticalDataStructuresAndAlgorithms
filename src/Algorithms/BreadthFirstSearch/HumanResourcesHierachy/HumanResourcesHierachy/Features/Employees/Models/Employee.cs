using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesHierachy.Features.Employees.Models;

public sealed class Employee
{

    public Employee()
    {
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public Guid EmployeeNumber { get; set; } = Guid.NewGuid();
    [Required, StringLength(100),]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    public int? ManagerId { get; set; }
    public Employee Manager { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateOnly DateOfBirth { get; set; }
    [Required]
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public ICollection<Employee> Subordinates { get; init; } = new List<Employee>();
    public ICollection<EmployeeRole> EmployeeRoles { get; init; } = new List<EmployeeRole>();

}

