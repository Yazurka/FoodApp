using FoodApp.Models;
using FoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Facade
{
    public class FoodFacade
    {
        private readonly IRestClient m_restClient;

        public FoodFacade(IRestClient restClient)
        {
            m_restClient = restClient;
        }
        public async Task<List<DishLight>> GetDishesLight(int limit, int offset)
        {


            //var res = await m_restClient.Get<List<DishLight>>($"Dish?limit={limit}&offset={offset}");

            //return res;
            return await Task.Run(
                        () =>
                            new List<DishLight>
                            {
                                new DishLight()
                                {
                                    Id = 1,
                                    Name = "Grillfest",
                                    Author = "Marius",
                                    Description = "Noe mat greier?",
                                    Difficulty = 10,
                                    Duration = 60,
                                    Tags = new List<Tag>() { new Tag { Name = "GrillFest" }, new Tag { Name = "Kake" } },
                                    TimeAdded = new DateTime(2014, 2,8)
                                },
                                new DishLight()
                                {
                                    Id = 2,
                                    Name = "Suppe",
                                    Author = "Erik",
                                    Description = "Noe mat greier?",
                                    Difficulty = 10,
                                    Duration = 60,
                                    Tags = new List<Tag>() { new Tag { Name = "Suppe" }, new Tag { Name = "Kake" } },
                                    TimeAdded = new DateTime(2010, 2,8)
                                }
                            });
        }
    }
}
