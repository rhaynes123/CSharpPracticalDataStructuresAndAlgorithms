using System;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Features.Movies.Extensions;
namespace Movies.Features.Movies.Extensions
{
	public static class IEnumerableExtension
	{
        /// <summary>
        /// Extends the INumerable interface to interact with a cache and return an IQueryable of that data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="cache"></param>
        /// <param name="Key"></param>
        /// <returns>IQueryable<T></returns>
        public static async Task<IQueryable<T>> AsCachedQueryable<T>(this IEnumerable<T> queryable
			, IDistributedCache cache
			, string Key)
		{
			(bool connected, IEnumerable<T> data) content = await cache.TryGetValuesAsync<IEnumerable<T>>(Key);
			if (!content.connected)
			{
                return queryable.AsQueryable();
            }
			if (content.connected && content.data is null || !content.data.Any())
			{
				_ = await cache.TrySetValuesAsync<IEnumerable<T>>(Key, queryable);
			}
            return queryable.AsQueryable();
        }
	}
}

