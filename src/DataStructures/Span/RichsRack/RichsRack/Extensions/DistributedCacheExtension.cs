using System;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using System.Text.Json;

namespace RichsRack.Extensions
{
    #region Helpful Redis Commands
    // " keys * " This command will show all keys aka databases in a redis serve
    // " hgetall <key>" Ex. "hgetall MoviesMovies_Redis_Key" This get all data for that key
    // " hget <key> data " Ex. "hget MoviesMovies_Redis_Key data" This will get specifically the data field of that key
    #endregion
    #region Helpful Links
    // https://www.youtube.com/watch?v=UrQWii_kfIE
    // https://sahansera.dev/distributed-caching-aspnet-core-redis/
    #endregion
    /// <summary>
    /// Extension to the IDistributedCache
    /// </summary>
    /// <remarks> Run this command if you want to create the redis docker image manually" docker run --name redis-cache -p 5002:6379 -d redis " </remarks>
    public static class DistributedCacheExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="distributedCache"></param>
        /// <param name="keyId"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <param name="slidingExpireTime"></param>
        /// <returns></returns>
        public static async Task<(bool, string)> TrySetValuesAsync<T>(this IDistributedCache distributedCache
            , string keyId
            , T data
            , TimeSpan? expireTime = null
            , TimeSpan? slidingExpireTime = null)
        {
            try
            {
                var cacheOption = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromMinutes(30),
                    SlidingExpiration = slidingExpireTime,
                };
                var json = JsonSerializer.Serialize(data);
                await distributedCache.SetStringAsync(key: keyId, value: json, options: cacheOption);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Attempts to GetValues from Cache. Will Not throw exceptions but instead return a tuple contain true and false on connection and an error message string.
        /// The string will be empty if no errors occured
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="distributedCache"></param>
        /// <param name="keyId"></param>
        /// <returns>A tuple of bool, the type searched for and a string. Second Item will be data retrieved</returns>

        public static async Task<(bool, T)> TryGetValuesAsync<T>(this IDistributedCache distributedCache, string keyId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyId))
                {
                    throw new ArgumentNullException(nameof(keyId));
                }
                string jsonAsString = await distributedCache.GetStringAsync(key: keyId) ?? string.Empty;

                if (string.IsNullOrWhiteSpace(jsonAsString))
                {
                    return (true, default!);
                }
                var result = JsonSerializer.Deserialize<T>(jsonAsString) ?? default!;
                return (true, result);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return (false, default!);
            }
        }

        public static async ValueTask TryRemoveAsync(this IDistributedCache cache, string key)
        {
            try
            {
                await cache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }
    }
}

