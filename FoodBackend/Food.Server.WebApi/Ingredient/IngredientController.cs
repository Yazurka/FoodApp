using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Food.Server.WebApi.Ingredient
{
    public class IngredientController : ApiController
    {
        public async Task<string> Get(string id)
        {
            await Task.Delay(1);
            var result = "hello to u";
            return result;
        }
    }
}
