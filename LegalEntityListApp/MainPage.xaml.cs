using System;
using LegalEntityListApp.ViewModels;
using Xamarin.Forms;

namespace LegalEntityListApp
{
    public partial class MainPage : ContentPage
    {
        private readonly LegalEntityListViewModel _legalEntityList;

        public MainPage(LegalEntityListViewModel legalEntityList)
        {
            InitializeComponent();
            _legalEntityList = legalEntityList;
            BindingContext = _legalEntityList;

            companiesList.RemainingItemsThreshold = 5;
            companiesList.RemainingItemsThresholdReached += CompaniesList_RemainingItemsThresholdReached;
        }

        private void CompaniesList_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            _legalEntityList.GetCompanies();
        }

        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adding", "Adding Test", "OK");
        }
    }
}
    