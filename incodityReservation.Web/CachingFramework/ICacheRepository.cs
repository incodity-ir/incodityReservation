namespace incodityReservation.Web.CachingFramework
{
    public interface ICacheRepository
    {
        public void Save<T>(string Key, T Value);
    }
}
