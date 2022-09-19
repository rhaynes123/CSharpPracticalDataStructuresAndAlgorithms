using System;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees.Models.Enums;

namespace HumanResourcesHierachy.Features.Employees.DTOS
{
    public sealed record EmployeeDTO
    {
        public Employee Employee { get; init; }
        public Role CurrentRole { get; init; }
        public IReadOnlyList<EmployeeRole> Roles { get; init; }
        // TODO I hope to be able to remove this since the employee has a property for its children now
        public IList<Employee> Subordinates { get; init; } = new List<Employee>();
        public bool IsManager { get; set; }

        public EmployeeDTO(Employee employee, Role currentRole, IEnumerable<EmployeeRole> roles, IEnumerable<Employee> subordinates)
        {
            if (employee is null
                || employee == default
                || currentRole == Role.None
                || roles is null
                || !roles.Any())
            {
                throw new InvalidOperationException("Insuffiecient Data Was Passed to the DTO constructor check values provided");
            }
            Employee = employee;
            CurrentRole = currentRole;
            Roles = roles.ToList();
            Subordinates = subordinates.ToList();
            IsManager = HasManagerRole();
        }

        private bool HasManagerRole()
        {
            return CurrentRole == Role.Manager || CurrentRole == Role.CTO || CurrentRole == Role.CEO;
        }
    }
}

