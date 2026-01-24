using AutoMapper;
using CleanArch.Application.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArch.Application.DataBase.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IGetAllCategoriesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        private const string CategoryCacheKey = Constants.CATEGORY_CACHE_KEY;

        public GetAllCategoriesQuery(IDataBaseService dataBaseService, IMapper mapper, IMemoryCache memoryCache)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _cache = memoryCache;
        }

        public async Task<List<GetAllCategoriesModel>> Execute()
        {
            if (!_cache.TryGetValue(CategoryCacheKey, out List<GetAllCategoriesModel>? cachedCategories))
            {
                var listEntity = await _dataBaseService.Categories.ToListAsync();

                cachedCategories = _mapper.Map<List<GetAllCategoriesModel>>(listEntity);
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                _cache.Set(CategoryCacheKey, cachedCategories, cacheOptions);
            }

            return cachedCategories!;
        }
    }
}
