using System;
using DebtForgivenessRegistration.Data;
using DebtForgivenessRegistration.Features.Customers.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DebtForgivenessRegistration.Features.Customers
{
    public sealed class GetCustomersQueryHandler: IRequestHandler<GetCustomersQuery, IQueryable<Customer>>
    {
        private readonly RegistrarDbContext _dbContext;
        public GetCustomersQueryHandler(RegistrarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_dbContext.Customers);
        }
    }
}

