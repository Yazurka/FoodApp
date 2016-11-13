using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using FoodAdmin.Models;
using FoodAdmin.Util;

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

        public Task<List<DishLight>> GetAllDishes()
        {
            //var res = await m_restClient.Get<List<DishLight>>(0, "Dish");

            return Task.Run(
                        () =>
                            new List<DishLight>
                            {
                                new DishLight()
                                {
                                    Name = "Graffi grillfest yo",
                                    Author = "Erik er best",
                                    Description = "Noe mat greier?",
                                    Difficulty = 10,
                                    Duration = "1 time",
                                    Tags = new List<Tag>() { new Tag { Name = "GrillFest" }, new Tag { Name = "Kake" } },
                                    TimeAdded = new DateTime(1990, 2,8)
                                },
                                new DishLight()
                                {
                                    Name = "Graffi grillfest yo",
                                    Author = "Erik er best",
                                    Description = "Noe mat greier?",
                                    Difficulty = 10,
                                    Duration = "1 time",
                                    Tags = new List<Tag>() { new Tag { Name = "GrillFest" }, new Tag { Name = "Kake" } },
                                    TimeAdded = new DateTime(1990, 2,8)
                                }
                            });
        }

        public  Task<List<Ingredient>> GetAllIngredients()
        {
            return Task.Run(
                () => new List<Ingredient>{
                    new Ingredient() { Name = "Biff", Description = "Fra okse" },
                    new Ingredient() { Name = "Kylling", Description = "Fersk" },
                    new Ingredient() { Name = "Safran", Description = "Dyrt krydder. Kan erstattes av gurkemeie, for dårligere resultat" },
                    new Ingredient() { Name = "Torsk", Description = "Fra Lofoten" },
                });
        }

        public Task<List<Tag>> GetAllTags()
        {
            //var tags = await m_restClient.Get<List<Tag>>(0, "tag");
            return
                    Task.Run(
                        () =>
                            new List<Tag>
                            {
                                new Tag { Name = "Grillfest" },
                                new Tag { Name = "Kake" },
                                new Tag { Name = "Biff" },
                                new Tag { Name = "Matpakke" },
                            });
        }

        public Task UpdateTag(Tag tag)
        {
            return Task.CompletedTask;
        }

        public Task<Tag> AddTag(Tag tag)
        {
            //var newtag = await m_restClient.Post<Tag>(new Tag() { Name = TagName }, "tag");
            return Task.Run(() => tag);
        }

        public Task DeleteTag(Tag tag)
        {
            return Task.CompletedTask;
        }

        public async Task<List<DishIngredientResult>> GetIngredientsForDish(DishLight dish)
        {
            return await Task.Run(() => new List<DishIngredientResult> { new DishIngredientResult() { Description = "Desc", Name = "lol?" } });
        }

        public Task<DishImage> GetImageForDish(DishLight dish)
        {
            return Task.Run(() => new DishImage() { });
        }

        public Task SaveDish(DishImage image, DishLight dish, List<DishIngredientResult> ingredients, List<Step> steps )
        {
            return Task.CompletedTask;
        }

        public Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            return Task.Run(() => ingredient);
        }

        public Task DeleteIngredient(Ingredient selectedIngredient)
        {
            return Task.CompletedTask;
        }

        public Task UpdateIngredient(Ingredient selectedIngredient)
        {
            return Task.CompletedTask;
        }
    }
}