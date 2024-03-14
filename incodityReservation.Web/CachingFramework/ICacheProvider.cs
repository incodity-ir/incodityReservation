namespace incodityReservation.Web.CachingFramework
{
    public interface ICacheProvider
    {
        public T Get<T>(string key);
    }
}
