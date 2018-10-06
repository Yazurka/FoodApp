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

        public async Task AddTagsToDish(DishTagCreateRequest dishTagCreateRequest)
        {
            var dishTagCommands = new List<DishTagCommand>();
            foreach (var tagId in dishTagCreateRequest.TagIds)
            {
                dishTagCommands.Add(new DishTagCommand
                {
                    Id = m_idGenerator.GenerateId(),
                    Dish_id_fk = dishTagCreateRequest.DishId,
                    Tag_id_fk = tagId
                });
            }
         await m_commandExecutor.ExecuteAsync(dishTagCommands.AsEnumerable());
        }

        public async Task RemoveTagsFromDish(int dishId, int[] tagIds)
        {
            List<DeleteDishTagCommand> deleteDishTagCommands = new List<DeleteDishTagCommand>();
            foreach (var tagId in tagIds)
            {
                deleteDishTagCommands.Add(new DeleteDishTagCommand
                {
                   Dish_id_fk = dishId,
                   Tag_id_fk = tagId
                    
                });
            }
           
            await m_commandExecutor.ExecuteAsync(deleteDishTagCommands.AsEnumerable());
            
        }
    }
}
