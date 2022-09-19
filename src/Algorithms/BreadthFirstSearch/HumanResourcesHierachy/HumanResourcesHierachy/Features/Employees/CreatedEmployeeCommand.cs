using System;
using HumanResourcesHierachy.Features.Employees.Models;
using MediatR;
namespace HumanResourcesHierachy.Features.Employees
{
    public sealed record CreatedEmployeeCommand(Employee Employee): IRequest<Employee>;
}

