using System;
using Mediator;
using RichsRack.Persistence;

namespace RichsRack.Features.Transactions
{
	public class CreateTransactionsNotificationHandler: INotificationHandler<CreateTransactionNotification>
	{
        private readonly SnacksDbContext dbContext;
        public CreateTransactionsNotificationHandler(SnacksDbContext dbContext)
		{
            this.dbContext = dbContext;
		}

        public async ValueTask Handle(CreateTransactionNotification notification, CancellationToken cancellationToken)
        {
            await dbContext.Transactions.AddAsync(notification.Transaction);
            await dbContext.SaveChangesAsync();
        }
    }
}

