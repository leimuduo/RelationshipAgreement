namespace RelationshipApi.Services.Interfaces
{
    public interface ICacheService
    {
        T TryGetValue<T>(string key);
        void SetCacheValue<T>(string key, T value);
        void RemoveValue<T>(string key);
    }
}