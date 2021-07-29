using LegalEntityListApp.ViewModels;
using Xamarin.Forms;

namespace LegalEntityListApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel { Navigation = this.Navigation };
            BindingContext = _viewModel;
        }
    }
}
    