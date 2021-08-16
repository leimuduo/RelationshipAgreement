using System;
using Microsoft.Extensions.Caching.Memory;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Services.Implementation
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly int _defaultCacheTime = 300; // 5 min

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }


        public T TryGetValue<T>(string key)
        {
            try
            {
                _cache.TryGetValue(key, out T cachedObj);
                return cachedObj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetCacheValue<T>(string key, T value)
        {
            try
            {
                _cache.Set(key, value, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(_defaultCacheTime)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoveValue<T>(string key)
        {
            try
            {
                _cache.Remove(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}