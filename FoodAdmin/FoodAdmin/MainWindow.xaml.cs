using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using FoodAdmin.ViewModels;

namespace FoodAdmin
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            Compose();
        }

        [Import]
        public FoodAdminViewModel ViewModel { get; set; }

        private async void Compose()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
            new CompositionContainer(catalog).ComposeParts(this);

            DataContext = ViewModel;

            await ViewModel.Initialize();
        }
    }
}
