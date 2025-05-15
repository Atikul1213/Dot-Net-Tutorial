using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace FirstCoreMVCWebApplication.Caching.Services
{
    public class CacheManager
    {
        private readonly IMemoryCache _cache;
        private readonly ConcurrentDictionary<string, bool> _cacheKeys;
        public CacheManager(IMemoryCache cache)
        {
            _cache = cache;
            _cacheKeys = new ConcurrentDictionary<string, bool>();
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options)
        {
            _cache.Set(key, value, options);
        }

        public bool TryGetValue<T>(string key, out T? value)
        {
            if (_cache.TryGetValue(key, out value))
                return true;

            _cacheKeys.TryRemove(key, out _);
            value = default;
            return false;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
            _cacheKeys.TryRemove(key, out _);
        }

        public List<string> GetAllKeys()
        {
            return _cacheKeys.Keys.ToList();
        }

        public void Clear()
        {
            foreach (var key in _cacheKeys.Keys)
            {
                _cache.Remove(key);
            }
            _cacheKeys.Clear();
        }
    }
}
