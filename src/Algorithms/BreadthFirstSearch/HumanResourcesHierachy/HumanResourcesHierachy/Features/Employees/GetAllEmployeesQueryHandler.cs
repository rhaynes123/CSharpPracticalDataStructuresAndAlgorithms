using System;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees.Repositories;
using MediatR;
namespace HumanResourcesHierachy.Features.Employees
{
    public sealed class GetAllEmployeesQueryHandler: IRequestHandler<GetAllEmployeesQuery, IQueryable<Employee>>
    {
        private readonly IEmployeeRepository _repository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllEmployeesAsync();
        }
    }
}

