using System;
using HumanResourcesHierachy.Features.Employees.DTOS;
using MediatR;
namespace HumanResourcesHierachy.Features.Employees
{
    public sealed record GetEmployeeByIdQuery(int id): IRequest<EmployeeDTO>;
}

