using System;
using LegalEntityListApp.ViewModels;
using Xamarin.Forms;

namespace LegalEntityListApp
{
    public partial class MainPage : ContentPage
    {
        private readonly LegalEntityListViewModel _legalEntityList;

        public MainPage()
        {
            InitializeComponent();
            _legalEntityList = new LegalEntityListViewModel();
            BindingContext = _legalEntityList;
        }

        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}
