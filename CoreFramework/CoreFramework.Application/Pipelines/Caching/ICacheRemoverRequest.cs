namespace CoreFramework.Application.Pipelines.Caching;

public interface ICacheRemoverRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
}