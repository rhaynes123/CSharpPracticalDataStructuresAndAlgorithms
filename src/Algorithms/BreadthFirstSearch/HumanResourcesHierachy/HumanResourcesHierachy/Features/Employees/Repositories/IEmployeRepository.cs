using System;
using HumanResourcesHierachy.Features.Employees.DTOS;
using HumanResourcesHierachy.Features.Employees.Models;

namespace HumanResourcesHierachy.Features.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IQueryable<Employee>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int Id);
        Task<bool> CreateEmployeeAsync(Employee employee);
    }
}

