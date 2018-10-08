using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodAdmin.Util;
using Newtonsoft.Json;

namespace FoodAdmin.Models
{
    public class Dish : ViewModelBase
    {
        private ObservableCollection<Step> m_steps; 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Recipe { get; set; }
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
                    if (Recipe.Count>0)
                    {
                        m_steps = new ObservableCollection<Step>();
                    }
                    else
                    {
                       
                        var steps = new ObservableCollection<Step>();
                        foreach (var s in Recipe)
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