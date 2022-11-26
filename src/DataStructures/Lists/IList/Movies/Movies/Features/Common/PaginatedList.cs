using System;
using Microsoft.EntityFrameworkCore;

namespace Movies.Features.Common
{
    #region Links
    // https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-7.0
    // https://www.mikesdotnetting.com/article/328/simple-paging-in-asp-net-core-razor-pages
    #endregion
    public class PaginatedList<T>: List<T>
	{
		public int PagedIndex { get; private set; }
		public int Total { get; private set; }
		public PaginatedList()
		{
				
		}
		public PaginatedList(IEnumerable<T> items, int count, int pagedIndex, int size)
		{
			PagedIndex = pagedIndex;
			Total = (int)Math.Ceiling(count / (double)size);
			this.AddRange(items);
		}

		public bool HasPrevious => PagedIndex > 1;

		public bool HasNext => PagedIndex < Total;

        public static PaginatedList<T> Create(IEnumerable<T> input, int pageIndex, int pageSize)
        {
            IList<T>? source = input as IList<T>;
            if (source is null || source.Count == 0)
            {
                throw new InvalidOperationException("Paginated List Can not be created from null or empty collection");
            }

            int count = source.Count;
            IEnumerable<T> queryedItems = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(queryedItems, count, pageIndex, pageSize);

        }

        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> input, int pageIndex, int pageSize)
		{
			IQueryable<T>? source = input as IQueryable<T>;
            if (source is null || !await source.AnyAsync())
			{
				throw new InvalidOperationException("Paginated List Can not be created from null or empty collection");
			}

			int count = await source.CountAsync();
			List<T> queryedItems = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
			return new PaginatedList<T>(queryedItems, count, pageIndex, pageSize);

		}
	}
}

