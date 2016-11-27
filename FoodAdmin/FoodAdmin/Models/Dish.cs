using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FoodAdmin.Models
{
    public class Dish
    {
        private ObservableCollection<Step> m_steps; 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
        public ObservableCollection<DishIngredientResult> Ingredients { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
        [JsonIgnore]
        public ObservableCollection<Step> Steps
        {
            get
            {
                if (m_steps == null)
                {
                    if (string.IsNullOrEmpty(Recipe))
                    {
                        m_steps = new ObservableCollection<Step>();
                    }
                    else
                    {
                        var stringList = JsonConvert.DeserializeObject<List<string>>(Recipe);
                        var steps = new ObservableCollection<Step>();
                        foreach (var s in stringList)
                        {
                            steps.Add(new Step {Value = s});
                        }
                        m_steps = steps;
                    }
                    
                }
                return m_steps;
            }
            
  
        }
    }
}