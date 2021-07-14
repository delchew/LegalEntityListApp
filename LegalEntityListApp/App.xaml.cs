using LegalEntityListApp.ViewModels;
using LegalEntityListApp.Views;
using Xamarin.Forms;

namespace LegalEntityListApp
{
    public partial class App : Application
    {
        private readonly MainPageViewModel _viewModel = new MainPageViewModel();

        public App()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(new MainPage(_viewModel))
            {
                BarTextColor = Color.FromHex("#25262E")
            };

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            _viewModel.GetCompanies();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
