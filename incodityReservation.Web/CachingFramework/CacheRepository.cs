using Enyim.Caching;

namespace incodityReservation.Web.CachingFramework
{
    public class CacheRepository:ICacheRepository
    {
        private readonly IMemcachedClient _memcachedClient;

        public CacheRepository(IMemcachedClient memcachedClient)
        {
            _memcachedClient = memcachedClient;
        }
        public void Save<T>(string Key, T Value)
        {
            _memcachedClient.Set(Key, Value, 60 * 1);
        }
    }
}
