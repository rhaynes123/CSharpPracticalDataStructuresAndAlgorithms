using System;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees.Repositories;
using MediatR;
namespace HumanResourcesHierachy.Features.Employees
{
    public class CreateEmployeeCommandHandler: IRequestHandler<CreatedEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _repository;
        public CreateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Handle(CreatedEmployeeCommand request, CancellationToken cancellationToken)
        {
            var saved = await _repository.CreateEmployeeAsync(request.Employee);
            return request.Employee;
        }
    }
}

