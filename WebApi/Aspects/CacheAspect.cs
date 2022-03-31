using Application.Abstracts;
using Microsoft.Extensions.Caching.Memory;

namespace TestAtch.Aspects;

public class CacheAspect<TRequest, TResponse> : IQueryHandler<TRequest, TResponse> 
    where TRequest : IQuery, ICacheable
    where TResponse : IResponse
{
    
    private readonly IQueryHandler<TRequest, TResponse> _decoratee;
    private readonly IMemoryCache _cache;

    public CacheAspect(IQueryHandler<TRequest, TResponse> decoratee, IMemoryCache cache)
    {
        _decoratee = decoratee;
        _cache = cache;
    }

    public TResponse Execute(TRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Key))
        {
            return _decoratee.Execute(request);
        }
        
        if (_cache.TryGetValue<TResponse>(request.Key, out var cachedResponse))
        {
            return cachedResponse;
        }

        var response = _decoratee.Execute(request);
        _cache.Set(request.Key, response);

        return response;
    }
}