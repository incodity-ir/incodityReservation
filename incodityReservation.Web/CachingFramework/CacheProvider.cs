using Enyim.Caching;
using incodityReservation.Web.CachingFramework;

namespace incodityReservation.Web.CachedFramework
{
    public class CacheProvider :ICacheProvider
    {
        private readonly IMemcachedClient _memcachedClient;

        public CacheProvider(IMemcachedClient memcachedClient)
        {
            _memcachedClient = memcachedClient;
        }
        public T Get<T>(string key)
        {
            return _memcachedClient.Get<T>(key);
        }
    }
}
