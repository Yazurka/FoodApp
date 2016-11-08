using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;
using Food.Server.Tag;

namespace Food.Server.DishTag
{
    public class DishTagService : IDishTagService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public DishTagService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<TagResult>> FindTagsForDish(int dishId)
        {
            var result = await m_queryExecutor.HandleAsync(new DishTagQuery { Id = dishId });
            return result;
        }
    }
}
