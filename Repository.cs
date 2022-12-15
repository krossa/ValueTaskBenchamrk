using Microsoft.Extensions.Caching.Memory;

public class Repository
{
    IMemoryCache _taskCache = new MemoryCache(new MemoryCacheOptions());
    IMemoryCache _valueCache = new MemoryCache(new MemoryCacheOptions());

    public async Task<string> GetDataWithTaskAsync(string cacheKey)
    {
        var value = _taskCache.Get<string>(cacheKey);
        if(value is null)
        {
            value = await GetData();
            _taskCache.Set(cacheKey, value, TimeSpan.FromHours(1));
        }
        return value;
    }

    public async ValueTask<string> GetDataWithValueTaskAsync(string cacheKey)
    {
        var value = _taskCache.Get<string>(cacheKey);
        if(value is null)
        {
            value = await GetData();
            _taskCache.Set(cacheKey, value, TimeSpan.FromHours(1));
        }
        return value;
    }

    private async Task<string> GetData()
    {
        await Task.Delay(500);
        return "data";
    }
}