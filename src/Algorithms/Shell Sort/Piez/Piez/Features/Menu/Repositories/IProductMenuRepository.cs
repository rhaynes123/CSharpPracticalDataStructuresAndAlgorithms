using System;
using Piez.Features.Menu.Models;
namespace Piez.Features.Menu.Repositories
{
	public interface IProductMenuRepository
	{
		Task<Models.Menu> GetProductMenuAsync();
	}
}

