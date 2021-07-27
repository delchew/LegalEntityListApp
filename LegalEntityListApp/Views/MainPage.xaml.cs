using LegalEntityListApp.ViewModels;
using Xamarin.Forms;

namespace LegalEntityListApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}
    