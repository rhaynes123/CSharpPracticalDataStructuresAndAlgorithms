using System;
using MediatR;
using HumanResourcesHierachy.Features.Employees;
using HumanResourcesHierachy.Features.Employees.Repositories;
using HumanResourcesHierachy.Features.Employees.DTOS;

namespace HumanResourcesHierachy.Features.Employees
{
    public sealed class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeRepository _repository;
        public GetEmployeeByIdQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeByIdAsync(request.id);
        }
    }
}

