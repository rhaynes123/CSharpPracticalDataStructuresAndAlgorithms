using System;
using Microsoft.EntityFrameworkCore;
using Piez.Features.Products.Entity;

namespace Piez.Data
{
	public class ProductsContext: DbContext
	{
		public ProductsContext(DbContextOptions<ProductsContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; } = default!;
	}
}

