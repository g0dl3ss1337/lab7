using System;
using System.Collections.Generic;

namespace Task3;
public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
    private readonly Func<TKey, TResult> function;

    public FunctionCache(Func<TKey, TResult> function)
    {
        this.function = function;
    }

    public TResult GetResult(TKey key, TimeSpan cacheDuration)
    {
        if (cache.TryGetValue(key, out var cacheItem) && IsCacheValid(cacheItem, cacheDuration))
        {
            return cacheItem.Result;
        }

        var result = function(key);
        cache[key] = new CacheItem(result, DateTime.Now);
        return result;
    }

    private bool IsCacheValid(CacheItem cacheItem, TimeSpan cacheDuration)
    {
        var expirationTime = cacheItem.Timestamp.Add(cacheDuration);
        return DateTime.Now <= expirationTime;
    }

    private class CacheItem
    {
        public TResult Result { get; }
        public DateTime Timestamp { get; }

        public CacheItem(TResult result, DateTime timestamp)
        {
            Result = result;
            Timestamp = timestamp;
        }
    }
}
