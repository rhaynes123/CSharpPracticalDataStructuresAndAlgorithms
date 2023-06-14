using System;
using System.Linq.Expressions;
using DebtForgivenessRegistration.Features.Customers.Models;
/*
 * https://www.youtube.com/watch?v=rdY5ElleWKY
 * https://enterprisecraftsmanship.com/posts/specification-pattern-c-implementation/
 * https://medium.com/c-sharp-progarmming/specification-design-pattern-c814649be0ef
 * https://www.c-sharpcorner.com/article/the-specification-pattern-in-c-sharp/
 * https://github.com/dotnet-architecture/eShopOnWeb/tree/main/src/ApplicationCore/Specifications
 */
namespace DebtForgivenessRegistration.Features.Customers.Specifications
{
	public sealed record CustomerWithDebtSpecification: ISpecification<Customer>
	{
        private readonly Customer _customer;
		public CustomerWithDebtSpecification(Customer customer)
		{
            _customer = customer;
		}

        public Expression<Func<Customer, bool>> Expression()
        {
            return cust => _customer.AgeOfDebt > 4 && _customer.DebtAmount > 10_000m;
        }

        public bool SatisfiedBy(Customer item)
        {
            Func<Customer, bool> predicate = Expression().Compile();
            return predicate(item);
        }
    }
}

