using System;
using HumanResourcesHierachy.DAL;
using HumanResourcesHierachy.Features.Employees.DTOS;
using HumanResourcesHierachy.Features.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesHierachy.Features.Employees.Repositories
{
    public sealed class EmployeeRepository: IEmployeeRepository
    {
        #region Helpful Links
        // https://blog.jetbrains.com/dotnet/2021/02/24/entity-framework-core-5-pitfalls-to-avoid-and-ideas-to-try/
        // https://stackoverflow.com/questions/50897638/how-to-call-theninclude-twice-in-ef-core
        // https://www.bu.edu/lernet/artemis/years/2020/projects/FinalPresentations/HTML/htmlsteps.html
        #endregion
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            if(employee is null || employee == default)
            {
                throw new InvalidDataException("No Employee Information as provided");
            }

            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Employee>> GetAllEmployeesAsync()
        {
            return await Task.FromResult(_dbContext.Employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int Id)
        {
            var employee = await _dbContext.Employees
                .Include(emp => emp.Subordinates)
                .ThenInclude(sub => sub.Subordinates)
                .FirstOrDefaultAsync(emp => emp.Id == Id);

            if(employee is null || employee == default)
            {
                return null!;
            }

            var employeeRoles = await _dbContext.EmployeeRoles
                .Where(empRole => empRole.Employee.Id == Id)
                .OrderByDescending( role => role)
                .ToArrayAsync();

            var currentRole = employeeRoles.FirstOrDefault(role => role.DeactivatedDateTime is null, new EmployeeRole { Role = Models.Enums.Role.None});

            return new EmployeeDTO(employee: employee!, currentRole: currentRole!.Role, roles: employeeRoles, subordinates: employee.Subordinates);
        }

    }
}

