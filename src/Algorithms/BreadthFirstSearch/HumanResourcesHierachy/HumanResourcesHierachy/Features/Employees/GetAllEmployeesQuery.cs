using System;
using HumanResourcesHierachy.Features.Employees.Models;
using MediatR;

namespace HumanResourcesHierachy.Features.Employees
{
    public record GetAllEmployeesQuery(): IRequest<IQueryable<Employee>>;
}

