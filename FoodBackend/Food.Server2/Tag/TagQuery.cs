using System.Collections.Generic;
using Food.Server.Query;

namespace Food.Server.Tag
{
    public class TagQuery : IQuery<IEnumerable<TagResult>>
    {
        public int Id { get; set; }
    }
}
