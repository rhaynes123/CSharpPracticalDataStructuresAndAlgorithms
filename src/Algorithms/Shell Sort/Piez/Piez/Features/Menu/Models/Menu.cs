using System;
using Microsoft.OpenApi.Services;
using Piez.Features.Products.Entity;
namespace Piez.Features.Menu.Models;
#region
/*
 * https://code-maze.com/shell-sort-csharp/
 */
#endregion

public sealed record Menu
{
	public IReadOnlyList<Product> Products { get { return _products; } }
	private List<Product> _products { get; init; } = new List<Product>();
        public Menu()
	{
	}

        public Menu(IEnumerable<Product> products)
        {
		_products = Sort(products).ToList();
        }

        public static IList<Product> Sort(IEnumerable<Product> products)
	{
		//if(products is null || !products.Any())
		//{
		//	throw new InvalidOperationException("Collection Can Not Be Null Or Empty");
		//}
		IList<Product> values = products as IList<Product> ?? new List<Product>();
		if (values is null || !values.Any())
		{
			return new List<Product>();
            }
		int size = values.Count;
		for (int interval = size / 2; interval > 0; interval /= 2)
		{
			for (int index = interval; index < size; index++)
			{
				var current = values[index];
                    var innerKey = index;

                    while (innerKey >= interval && values[innerKey - interval].Price > current.Price)
                    {
                        values[innerKey] = values[innerKey - interval];
                        innerKey -= interval;
                    }
                }
		}
		return values!;
	}
}

