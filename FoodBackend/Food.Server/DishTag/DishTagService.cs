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

        public async Task AddTagsToDish(int dishId, int[] TagIds)
        {
            List<DishTagCommand> dishTagCommands = new List<DishTagCommand>();
            foreach (var tagId in TagIds)
            {
                dishTagCommands.Add(new DishTagCommand
                {
                    Id = m_idGenerator.GenerateId(),
                    Dish_id_fk = dishId,
                    Tag_id_fk = tagId
                });
            }
            //TODO: forbedre med tanke på sql
            foreach (var dishTagCommand in dishTagCommands)
            {
                await m_commandExecutor.ExecuteAsync(dishTagCommand);
            }
        }

        public async Task RemoveTagsFromDish(int[] dishTagIds)
        {
            List<DeleteDishTagCommand> deleteDishTagCommands = new List<DeleteDishTagCommand>();
            foreach (var tagId in dishTagIds)
            {
                deleteDishTagCommands.Add(new DeleteDishTagCommand
                {
                    Id = tagId,
                    
                });
            }
            //TODO: forbedre med tanke på loop sql
            foreach (var deleteDishTagCommand in deleteDishTagCommands)
            {
                await m_commandExecutor.ExecuteAsync(deleteDishTagCommand);
            }
        }
    }
}
