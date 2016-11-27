using System.Collections.Generic;
using System.Threading.Tasks;
using Food.Server.Dish;
using Food.Server.DishTag;
using Food.Server.Query;
using Food.Server.Tag;

namespace Food.Server.Search
{
    public class SearchService : ISearchService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly IDishTagService m_dishTagService;

        public SearchService(IQueryExecutor queryExecutor, IDishTagService dishTagService)
        {
            m_queryExecutor = queryExecutor;
            m_dishTagService = dishTagService;
        }

        public async Task<IEnumerable<DishLight>> Search(string parameter, int limit, int offset)
        {
            var dishes = new List<DishLight>();
            IEnumerable<DishLightResult> dishLightResult = await m_queryExecutor.HandleAsync(
                new SearchQuery
                {
                    Parameter = "%"+parameter+"%",
                    Limit = limit,
                    Offset = offset
                }
                );
            foreach (var dishResult in dishLightResult)
            {
                IEnumerable<TagResult> tags = await m_dishTagService.FindTagsForDish(dishResult.Id);
                dishes.Add(new DishLight
                {
                    Id = dishResult.Id,
                    Name = dishResult.Name,
                    Description = dishResult.Description,
                    Difficulty = dishResult.Difficulty,
                    Duration = dishResult.Duration,
                    Author = dishResult.Author,
                    TimeAdded = dishResult.TimeAdded,
                    Tags = tags

                });
            }
            return dishes;
        }
    }
}
