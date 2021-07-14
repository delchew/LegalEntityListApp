using System;
using LegalEntityListApp.ViewModels;
using Xamarin.Forms;

namespace LegalEntityListApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

            companiesList.RemainingItemsThreshold = 5;
            companiesList.RemainingItemsThresholdReached += CompaniesList_RemainingItemsThresholdReached;
        }

        private void CompaniesList_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            _viewModel.GetCompanies();
        }

        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage(new MapPageViewModel(_viewModel)));
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adding", "Adding Test", "OK");
        }
    }
}
    