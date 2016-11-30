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
using MahApps.Metro.Controls.Dialogs;

namespace FoodAdmin.ViewModels
{
    [Export]
    public class DishViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;
        private DishLight m_selectedDish;
        private readonly IViewDisabler m_viewDisabler;
        private readonly PopupDialog m_popupDialog ;
        private Dish m_theDish;

        [ImportingConstructor]
        public DishViewModel(FoodFacade foodFacade, IViewDisabler viewDisabler, IngredientViewModel ingredientViewModel, TagViewModel tagViewModel, PopupDialog popupDialog)
        {
            m_foodFacade = foodFacade;
            m_viewDisabler = viewDisabler;
            TagViewModel = tagViewModel;
            IngredientViewModel = ingredientViewModel;
            m_popupDialog = popupDialog;

        }
        public IngredientViewModel IngredientViewModel { get; }
        public TagViewModel TagViewModel { get; }
        public DelegateCommand CreateNewDishCommand => new DelegateCommand(CreateNewDish);
        public DelegateCommand NewStepCommand => new DelegateCommand(CreateNewStep);
        public DelegateCommand RemoveLastStepCommand => new DelegateCommand(RemoveLastStep);
        public Command RemoveIngredientFromDishCommand => new Command(RemoveIngredientFromDish);
        public Command RemoveTagFromDishCommand => new Command(RemoveTagFromDish);




        public DelegateCommand CancelCommad => new DelegateCommand(Cancel);
        public DelegateCommand AddDishIngredientCommand => new DelegateCommand(AddDishIngredient, CanAddIngredient);

      

        public DelegateCommand AddTagCommand => new DelegateCommand(AddTag, CanAddTag);

       

        public DelegateCommand SaveCommand => new DelegateCommand(SaveDish, CanSaveDish);

        private bool CanSaveDish()
        {

            //return !string.IsNullOrEmpty(TheDish?.Name);
            return true;
        }

        public DelegateCommand DeleteCommand => new DelegateCommand(DeleteDish);

       

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

        public Dish TheDish
        {
            get { return m_theDish; }
            set
            {
                m_theDish = value; 
                OnPropertyChanged(nameof(TheDish));
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public async Task Initialize()
        {
            var dishes = await m_foodFacade.GetAllDishes(100000,0);
            dishes.Sort((light, dishLight) => light.Name.CompareTo(dishLight.Name));
            Dishes = new ObservableCollection<DishLight>(dishes);
            DishIngredientInProgress = new DishIngredientResult();
            TagInProgress = new Tag();
            OnPropertyChanged(nameof(Dishes));
        }
        private bool CanAddTag()
        {
            //return TagInProgress.Id != 0;
            return true;
        }
        private bool CanAddIngredient()
        {
           // return DishIngredientInProgress.Id != 0;
            return true;
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

        private async void Cancel()
        {
            MessageDialogStyle style = MessageDialogStyle.AffirmativeAndNegative;
            MetroDialogSettings settings = new MetroDialogSettings { AffirmativeButtonText = "Ja, jeg vil avbryte", NegativeButtonText = "Nei, ikke avbryt" };
            var answer = await m_popupDialog.Dialog.ShowMessageAsync(this, $"Avbryte redigering?", $"Vil du avbryte redigering av ''{TheDish.Name}'' og forkaste endringer som ikke er lagret?", style, settings);

            if (answer == MessageDialogResult.Affirmative)
            {
                ResetDish();
            }
        }

        private void ResetDish()
        {
            TheDish = null;
            SelectedDish = null;
            OnPropertyChanged(nameof(TheDish));
        }

        private async void AddTag()
        {

            if (TagInProgress.Id == 0)
            {
               await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke legge til tag", "Taggen du prøver å legge til må velges fra nedtrekkslista");
               return;
            }
            if (DishAllreadyHasTag(TagInProgress))
            {
                await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke legge til tag", "Taggen du prøver å legge til har du allerede lagt til");
                return;
            }

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

        private bool DishAllreadyHasIngredient(DishIngredientResult dishIngredient)
        {
            var res = TheDish.Ingredients.Select(x => x.Id).Where(i => i== dishIngredient.Id).ToArray();
            return res.Count() > 0;
        }
        private bool DishAllreadyHasTag(Tag tag)
        {
            var res = TheDish.Tags.Select(x => x.Id).Where(i => i == tag.Id).ToArray();
            return res.Count() > 0;
        }
        private async void AddDishIngredient()
        {

            if (DishIngredientInProgress.Id == 0 || Math.Abs(DishIngredientInProgress.Amount) < 0.000000001 || string.IsNullOrEmpty(DishIngredientInProgress.Unit))
            {
                await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke legge til ingrediens", "Ingrediensen du prøver å legge til må velges fra nedtrekkslista, enhetsfeltet og mengdefeltet må ha en verdi");
                return;
            }
            if (DishAllreadyHasIngredient(DishIngredientInProgress))
            {
                await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke legge til ingrediens", "Ingrediensen du prøver å legge til har du allerede lagt til");
                return;
            }

            if (TheDish.Id != -1)
            {
                var dishIngredientsToPost = new List<DishIngredientCreateRequest>{new DishIngredientCreateRequest{
                    Amount = DishIngredientInProgress.Amount,
                    IngredientId = DishIngredientInProgress.Id,
                    Unit = DishIngredientInProgress.Unit,
                    Comment = DishIngredientInProgress.Comment
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
        private async void RemoveIngredientFromDish(object param)
        {
            var ingredient = param as DishIngredientResult;
            if (TheDish.Id == -1)
            {
                TheDish.Ingredients.Remove(ingredient);
                
            }
            else
            {
                await m_foodFacade.DeleteDishIngredient(TheDish.Id ,ingredient);
                TheDish.Ingredients.Remove(ingredient);
            }

        }
        private async void RemoveTagFromDish(object param)
        {
            var tag = param as Tag;
            if (TheDish.Id == -1)
            {
                TheDish.Tags.Remove(tag);

            }
            else
            {
                await m_foodFacade.DeleteDishTag(TheDish.Id, tag);
                TheDish.Tags.Remove(tag);
            }

        }
        private async void DeleteDish()
        {
            MessageDialogStyle style = MessageDialogStyle.AffirmativeAndNegative;
            MetroDialogSettings settings = new MetroDialogSettings { AffirmativeButtonText = "Ja, jeg vil slette", NegativeButtonText = "Nei, ikke slett" };
            var answer = await m_popupDialog.Dialog.ShowMessageAsync(this, $"Slette {TheDish.Name}?", $"Vil du slette ''{TheDish.Name}''?", style, settings);

            if (answer == MessageDialogResult.Affirmative)
            {
                if (TheDish.Id != -1)
                {
                    await m_foodFacade.DeleteDish(TheDish.Id);
                }
                await Initialize();
                ResetDish();
            }

        }
        private async void SaveDish()
        {
            if (string.IsNullOrEmpty(TheDish.Name))
            {
                await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke lagre", "Retten du prøver å lagre må ha en tittel for at lagringen skal være gyldig");
                return;
            }
            if (TheDish.Id == -1)
            {
                await m_foodFacade.CreateNewDish(TheDish);
                await Initialize();
                ResetDish();
                return;
            }
            
            await m_foodFacade.UpdateDish(TheDish);
            await Initialize();
            ResetDish();
        }
    }
}
