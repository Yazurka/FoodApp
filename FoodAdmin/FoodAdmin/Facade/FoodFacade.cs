using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Models;
using FoodAdmin.Util;
using Newtonsoft.Json;

namespace FoodAdmin.Facade
{
    [Export]
    public class FoodFacade
    {
        private readonly IRestClient m_restClient;

        [ImportingConstructor]
        public FoodFacade(IRestClient restClient)
        {
            m_restClient = restClient;
        }

        public async Task<Dish> GetDish(int id)
        {

            var res = await m_restClient.Get<Dish>(id, "Dish?id=");


            return res;

        }

        public async Task<List<DishLight>> GetAllDishes(int limit, int offset)
        {
            
                var res = await m_restClient.Get<List<DishLight>>(0, $"Dish?limit={limit}&offset={offset}");
            


            return res;

            //return Task.Run(
            //            () =>
            //                new List<DishLight>
            //                {
            //                    new DishLight()
            //                    {
            //                        Name = "Graffi grillfest yo",
            //                        Author = "Erik er best",
            //                        Description = "Noe mat greier?",
            //                        Difficulty = 10,
            //                        Duration = "1 time",
            //                        Tags = new List<Tag>() { new Tag { Name = "GrillFest" }, new Tag { Name = "Kake" } },
            //                        TimeAdded = new DateTime(1990, 2,8)
            //                    },
            //                    new DishLight()
            //                    {
            //                        Name = "Graffi grillfest yo",
            //                        Author = "Erik er best",
            //                        Description = "Noe mat greier?",
            //                        Difficulty = 10,
            //                        Duration = "1 time",
            //                        Tags = new List<Tag>() { new Tag { Name = "GrillFest" }, new Tag { Name = "Kake" } },
            //                        TimeAdded = new DateTime(1990, 2,8)
            //                    }
            //                });
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var res = await m_restClient.Get<List<Ingredient>>(0, "Ingredient");


            return res;
            //return Task.Run(
            //    () => new List<Ingredient>{
            //        new Ingredient() { Name = "Biff", Description = "Fra okse" },
            //        new Ingredient() { Name = "Kylling", Description = "Fersk" },
            //        new Ingredient() { Name = "Safran", Description = "Dyrt krydder. Kan erstattes av gurkemeie, for dårligere resultat" },
            //        new Ingredient() { Name = "Torsk", Description = "Fra Lofoten" },
            //    });
        }

        public async Task<List<Tag>> GetAllTags()
        {
            var tags = await m_restClient.Get<List<Tag>>(0, "tag");
            return tags;
            //return
            //        Task.Run(
            //            () =>
            //                new List<Tag>
            //                {
            //                    new Tag { Name = "Grillfest" },
            //                    new Tag { Name = "Kake" },
            //                    new Tag { Name = "Biff" },
            //                    new Tag { Name = "Matpakke" },
            //                });
        }

        public async Task UpdateTag(Tag tag)
        {
            await m_restClient.Put<Tag>(tag, "Tag");
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            var newtag = await m_restClient.Post<Tag>(tag, "tag");
            return newtag;
            //return Task.Run(() => tag);
        }

        public async Task DeleteTag(Tag tag)
        {
            await m_restClient.Delete(0, $"Tag?id={tag.Id}");
        }

        public async Task<List<DishIngredientResult>> GetIngredientsForDish(DishLight dish)
        {
           // return await Task.Run(() => new List<DishIngredientResult> { new DishIngredientResult() { Description = "Desc", Name = "lol?" } });
            var res = (await m_restClient.Get<List<DishIngredientResult>>(dish.Id, "DishIngredient?id="));
            return res;
        }

        public Task<DishImage> GetImageForDish(DishLight dish)
        {
            return Task.Run(() => new DishImage() { });
        }

        public async Task CreateNewDish(Dish dish)
        {
            var createRequest = new DishCreateRequest
            {
                Author = dish.Author,
                Description = dish.Description,
                Difficulty = dish.Difficulty,
                Duration = dish.Duration,
                Name = dish.Name,
                Recipe = JsonConvert.SerializeObject(dish.Steps),
                TagIds = dish.Tags.Select(x=>x.Id).ToArray(),
                DishIngredients = dish.Ingredients.Select(x=> new DishIngredientCreateRequest {Amount = x.Amount, IngredientId = x.Id, Unit = x.Unit}).ToArray()

            };
            await m_restClient.Post<Dish>(createRequest, "Dish");
           
        }
        public async Task UpdateDish(Dish dish)
        {
            var updateRequest = new UpdateDishRequest
            {
                Author = dish.Author,
                Description = dish.Description,
                Difficulty = dish.Difficulty,
                Duration = dish.Duration,
                Name = dish.Name,
                Recipe = JsonConvert.SerializeObject(dish.Steps),
            };
            await m_restClient.Put<Dish>(updateRequest, $"Dish?id={dish.Id}");
        }

        public async Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            //return Task.Run(() => ingredient);
            var res = await m_restClient.Post<Ingredient>(ingredient, "Ingredient");
            return res;
        }

        public async Task DeleteIngredient(Ingredient selectedIngredient)
        {
            await m_restClient.Delete(0, $"Ingredient?id={selectedIngredient.Id}");
        }

        public async Task UpdateIngredient(Ingredient selectedIngredient)
        {
            var res = await m_restClient.Put<Ingredient>(selectedIngredient, $"Ingredient?id={selectedIngredient.Id}");
 
        }

        public async Task AddIngredientToDish(int dishId, List<DishIngredientCreateRequest> dishIngredients)
        {
            await m_restClient.Post<DishIngredientCreateRequest>(dishIngredients, $"DishIngredient?dishid={dishId}");
        }

        public async Task AddTagsToDish(DishTagCreateRequest dishTagCreateRequest)
        {
            await m_restClient.Post<DishIngredientCreateRequest>(dishTagCreateRequest, "DishTag");
        }
    }
}