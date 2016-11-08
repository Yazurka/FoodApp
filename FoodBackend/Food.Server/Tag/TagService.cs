using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;

namespace Food.Server.Tag
{
    public class TagService : ITagService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public TagService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<TagResult>> GetAllTags()
        {
            var result = await m_queryExecutor.HandleAsync(new TagQuery());
            return result;
        }

        public async Task<TagResult> FindTag(int id)
        {
            var result = (await m_queryExecutor.HandleAsync(new TagQuery {Id = id})).FirstOrDefault();
            return result;
        }

        public async Task<TagResult> PostTag(TagCreateRequest tagCreateRequest)
        {
            var tagCommand = CreateTagCommand(tagCreateRequest);
            await m_commandExecutor.ExecuteAsync(tagCommand);
            var postedTag = await FindTag(tagCommand.Id);
            return postedTag;
        }

        public async Task DeleteTag(int id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteTagCommand { Id = id });
        }

        private TagCommand CreateTagCommand(TagCreateRequest tagRequest)
        {
            var tagCommand = new TagCommand
            {
                Id = m_idGenerator.GenerateId(),
                Name = tagRequest.Name
            };
            return tagCommand;
        }
    }
}
