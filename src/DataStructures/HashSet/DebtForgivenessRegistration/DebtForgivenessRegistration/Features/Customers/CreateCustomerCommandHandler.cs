using System;
using DebtForgivenessRegistration.Data;
using MediatR;

namespace DebtForgivenessRegistration.Features.Customers;
#region
/*
 * https://github.com/jbogard/MediatR/issues/382
 * https://samwalpole.com/writing-decoupled-code-with-mediatr-the-mediator-pattern
 */
#endregion
public sealed class CreateCustomerCommandHandler: INotificationHandler<CreateCustomerCommand>
{
    private readonly RegistrarDbContext _dbContext;
    public CreateCustomerCommandHandler(RegistrarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateCustomerCommand notification, CancellationToken cancellationToken)
    {
        await _dbContext.Customers.AddAsync(notification.Customer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await Task.CompletedTask;
    }
}

