using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Food.Server.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food.Server.WebApi.Ingredient
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService m_ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            m_ingredientService = ingredientService;
        }

        [HttpGet("{id}")]
        public async Task<IngredientResult> Get(int id)
        {
            var result = await m_ingredientService.FindIngredient(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientResult>> Get()
        {
            var result = await m_ingredientService.GetAllIngredients();
            return result;
        }

        [Authorize]
        [HttpPut]
        public async Task Put([FromRoute]int id, [FromBody]UpdateIngredientRequest updateIngredientRequest)
        {
            await m_ingredientService.UpdateIngredient(id, updateIngredientRequest);
        }

        [Authorize]
        [HttpPost]
        public async Task<IngredientResult> Post(IngredientCreateRequest ingredientCreateRequest)
        {
            var result = await m_ingredientService.PostIngredient(ingredientCreateRequest);
            return result;
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await m_ingredientService.DeleteIngredient(id);
        }
    }
}
