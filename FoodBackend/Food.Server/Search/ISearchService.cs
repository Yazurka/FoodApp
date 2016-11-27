using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Food.Server.Dish;

namespace Food.Server.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<DishLight>> Search(string parameter, int limit, int offset);
    }
}