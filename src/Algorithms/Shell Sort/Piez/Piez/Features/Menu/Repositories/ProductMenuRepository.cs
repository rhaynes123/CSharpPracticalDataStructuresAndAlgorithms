using System;
using Microsoft.EntityFrameworkCore;
using Piez.Data;
namespace Piez.Features.Menu.Repositories
{
	public class ProductMenuRepository: IProductMenuRepository
	{
        private readonly ProductsContext context;
		public ProductMenuRepository(ProductsContext context)
		{
            this.context = context;
		}

        public async Task<Models.Menu> GetProductMenuAsync()
        {
            var products = await context.Products.ToListAsync();
            return new Models.Menu(products);
        }
    }
}

