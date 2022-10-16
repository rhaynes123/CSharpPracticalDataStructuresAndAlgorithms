using System;
using DebtForgivenessRegistration.Features.Customers.Models;
using MediatR;

namespace DebtForgivenessRegistration.Features.Customers
{
    public sealed record CreateCustomerCommand(Customer Customer): INotification;
}

