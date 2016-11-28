using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodAdmin.Facade;
using FoodAdmin.Models;
using FoodAdmin.Util;

namespace FoodAdmin.ViewModels
{
    [Export]
    public class DishViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;
        private DishLight m_selectedDish;
        private readonly IViewDisabler m_viewDisabler;
       

        [ImportingConstructor]
        public DishViewModel(FoodFacade foodFacade, IViewDisabler viewDisabler, IngredientViewModel ingredientViewModel, TagViewModel tagViewModel)
        {
            m_foodFacade = foodFacade;
            m_viewDisabler = viewDisabler;
            TagViewModel = tagViewModel;
            IngredientViewModel = ingredientViewModel;
            
        }
        public IngredientViewModel IngredientViewModel { get; }
        public TagViewModel TagViewModel { get; }
        public DelegateCommand CreateNewDishCommand => new DelegateCommand(CreateNewDish);
        public DelegateCommand NewStepCommand => new DelegateCommand(CreateNewStep);
        public DelegateCommand RemoveLastStepCommand => new DelegateCommand(RemoveLastStep);
        public ICommand RemoveIngredientFromDishCommand => new DelegateCommand(RemoveIngredientFromDish);




        public DelegateCommand CancelCommad => new DelegateCommand(Cancel);
        public DelegateCommand AddDishIngredientCommand => new DelegateCommand(AddDishIngredient);
        public DelegateCommand AddTagCommand => new DelegateCommand(AddTag);

     

        public DelegateCommand SaveCommand => new DelegateCommand(SaveDish);
        public ObservableCollection<DishLight> Dishes { get; set; }
        public DishIngredientResult DishIngredientInProgress { get; set; }
        public Tag TagInProgress { get; set; }
        public string SearchText { get; set; }
        public string SearchTextTag { get; set; }

        public Tag SelectedTag
        {
            get
            {
                return null;
            }
            set
            {
                TagInProgress.Id = value?.Id ?? 0;
                TagInProgress.Name = value?.Name;
                SearchTextTag = value?.Name;
                OnPropertyChanged(nameof(SearchTextTag));
            }
        }

        public Ingredient SelectedIngredient
        {
            get { return null; }
            set
            {
                DishIngredientInProgress.Id = value?.Id?? 0;
                DishIngredientInProgress.Name = value?.Name;
                SearchText = value?.Name;
                OnPropertyChanged(nameof(SearchText));
            }
        }


        public DishLight SelectedDish
        {
            get { return m_selectedDish; }
            set
            {
                m_selectedDish = value;
                SelectionChanged();
            }
        }

       

        public Dish TheDish { get; set; }

        public async Task Initialize()
        {
            var dishes = await m_foodFacade.GetAllDishes(100000,0);
            dishes.Sort((light, dishLight) => light.Name.CompareTo(dishLight.Name));
            Dishes = new ObservableCollection<DishLight>(dishes);
            DishIngredientInProgress = new DishIngredientResult();
            TagInProgress = new Tag();
            OnPropertyChanged(nameof(Dishes));
        }
        private void CreateNewStep()
        {
            TheDish.Steps.Add(new Step());  
        }
        private void RemoveLastStep()
        {
            TheDish.Steps.RemoveAt(TheDish.Steps.IndexOf(TheDish.Steps.Last()));
        }

        private async void SelectionChanged()
        {
            if (SelectedDish == null)
            {
                OnPropertyChanged(string.Empty);
                return;
            }
            TheDish = await m_foodFacade.GetDish(SelectedDish.Id);
            DishIngredientInProgress = new DishIngredientResult();
            OnPropertyChanged(nameof(TheDish));
        }

        private void Cancel()
        {
            TheDish = null;
            SelectedDish = null;
            OnPropertyChanged(nameof(TheDish));
        }
        private async void AddTag()
        {
            
            if (TheDish.Id != -1)
            {
                var dishTagCreateRequest = new DishTagCreateRequest{
                    DishId = TheDish.Id,
                    TagIds = new []{TagInProgress.Id}
                };
                await m_foodFacade.AddTagsToDish(dishTagCreateRequest);
            }
            TheDish.Tags.Add(TagInProgress);
            TagInProgress = new Tag();
            SearchTextTag = "";
            OnPropertyChanged(nameof(SearchTextTag));
            OnPropertyChanged(nameof(TagInProgress));
        }
        private async void AddDishIngredient()
        {
          
            if (TheDish.Id != -1)
            {
                var dishIngredientsToPost = new List<DishIngredientCreateRequest>{new DishIngredientCreateRequest{
                    Amount = DishIngredientInProgress.Amount,
                    IngredientId = DishIngredientInProgress.Id,
                    Unit = DishIngredientInProgress.Unit
                }};
                await m_foodFacade.AddIngredientToDish(TheDish.Id, dishIngredientsToPost);
            }
            TheDish.Ingredients.Add(DishIngredientInProgress);
            DishIngredientInProgress = new DishIngredientResult();
            SearchText = "";
            OnPropertyChanged(nameof(SearchText));
            OnPropertyChanged(nameof(DishIngredientInProgress));

        }
        private void CreateNewDish()
        {
            TheDish = new Dish {Tags = new ObservableCollection<Tag>(), Ingredients = new ObservableCollection<DishIngredientResult>(),Id=-1};
            OnPropertyChanged(nameof(TheDish));
        }
        //Ta inn hvilken ing som er trykket på
        private void RemoveIngredientFromDish()
        {
           
            if (TheDish.Id == -1)
            {
               // TheDish.Ingredients.Remove(dishIngredient);
            }
        }

        private async void SaveDish()
        {
            if (TheDish.Id == -1)
            {
                await m_foodFacade.CreateNewDish(TheDish);
                await Initialize();
                Cancel();
                return;
            }
            await m_foodFacade.UpdateDish(TheDish);
            await Initialize();
            Cancel();
        }
    }
}
