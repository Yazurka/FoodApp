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
    public class TagViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;
        private readonly PopupDialog m_popupDialog;
        private readonly IViewDisabler m_viewDisabler;

        [ImportingConstructor]
        public TagViewModel(FoodFacade foodFacade, PopupDialog popupDialog, IViewDisabler viewDisabler)
        {
            m_foodFacade = foodFacade;
            m_popupDialog = popupDialog;
            m_viewDisabler = viewDisabler;
            Tags = new ObservableCollection<Tag>();
        }

        public ObservableCollection<Tag> Tags { get; private set; }
        public ICommand CreateNewTagCommand => new DelegateCommand(CreateNewTag);
        public ICommand SaveEditedTagCommand => new DelegateCommand(SaveEditedTag);
        public ICommand DeleteTagCommand => new DelegateCommand(DeleteTag);

        public string TagName { get; set; }

        public Tag SelectedTag { get; set; }

        public Task Initialize()
        {
            return RefreshTag();
        }

        private async void CreateNewTag()
        {
            if (TagName != null)
            {
                var numberOfEqualTags = Tags.Select(x => x).Where(t => t.Name.ToUpper().Equals(TagName.ToUpper())).ToArray().Count();
                if (numberOfEqualTags>0)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, $"Kan ikke legge til {TagName}", $"{TagName} kan ikke legges til fordi det eksisterer allerede en tag med samme navn");
                    return;
                }
                Tags.Add( await m_foodFacade.AddTag(new Tag() {Name = TagName}));
                TagName = "";
                OnPropertyChanged(nameof(TagName));
                m_viewDisabler.Disable("Laster...", RefreshTag());
            }
        }

        private async void DeleteTag()
        {
            if (m_popupDialog != null)
            {
                var status = await m_foodFacade.DeleteTag(SelectedTag);
                if (status == 500)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, $"Kan ikke slette {SelectedTag.Name}", $"{SelectedTag.Name} kan ikke slettes fordi den blir brukt i en eller flere av rettene. Slett retten(e) eller slett taggen ''{SelectedTag.Name}'' fra retten(e) ");
                    return;
                }
                m_viewDisabler.Disable("Laster...", RefreshTag());
            }
        }

        private async void SaveEditedTag()
        {
            if (SelectedTag != null)
            {
                var numberOfEqualTags = TagCopy.Select(x => x).Where(t => t.Name.ToUpper().Equals(SelectedTag.Name.ToUpper())).ToArray().Count();
                if (numberOfEqualTags > 0)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke endre navn på tag", $"Det eksisterer allerede en tag som heter {SelectedTag.Name}, velg et annet navn eller bruk den du allerede har");
                    m_viewDisabler.Disable("Laster...", RefreshTag());
                    return;
                }
                await m_foodFacade.UpdateTag(SelectedTag);
                m_viewDisabler.Disable("Laster...", RefreshTag());
            }
        }
        private List<Tag> TagCopy { get; set; } 
            private async Task RefreshTag()
            {
               TagCopy = new List<Tag>();
               var tags = await m_foodFacade.GetAllTags();
                foreach (var tag in tags)
                {
                   TagCopy.Add(new Tag {Id=tag.Id, Name = tag.Name});
                }

                tags.Sort((tag, tag1) => tag.Name.CompareTo(tag1.Name));
                Tags = new ObservableCollection<Tag>(tags);
                OnPropertyChanged(nameof(Tags));
            }
    }
}
