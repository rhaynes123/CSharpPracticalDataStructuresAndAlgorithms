using System;
using System.Linq.Expressions;

namespace DebtForgivenessRegistration.Features.Customers.Specifications
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Expression();
		bool SatisfiedBy(T item);
	}
}

