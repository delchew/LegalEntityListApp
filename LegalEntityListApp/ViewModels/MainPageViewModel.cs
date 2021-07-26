using System.Collections.ObjectModel;
using System.Collections.Generic;
using LegalEntityListApp.DataProviders;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Input;
using LegalEntityListApp.Views;
using System;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;

namespace LegalEntityListApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IContentProvider _contentProvider;
        private int _currentPageNumber = 0;
        public ObservableCollection<LegalEntityViewModel> Companies { get; private set; }
        public INavigation Navigation { get; set; }
        public View FilterView { get; set; }
        public ICommand OpenMapCommand { get; private set; }
        public ICommand LoadNextEntitiesPageCommand { get; private set; }
        public ICommand OpenFilterCommand { get; private set; }

        public MainPageViewModel()
        {
            Companies = new ObservableCollection<LegalEntityViewModel>();
            _contentProvider = DependencyService.Get<IContentProvider>();
            OpenMapCommand = new Command(OpenMap);
            LoadNextEntitiesPageCommand = new Command(GetCompanies);
            OpenFilterCommand = new Command(OpenFilter);
        }

        public async void GetCompanies()
        {
            var jsonString = await _contentProvider.GetContentAsync(++_currentPageNumber);
            if (!string.IsNullOrEmpty(jsonString))
            {
                var companies = ParseContent(jsonString);
                foreach (var company in companies)
                {
                    Companies.Add(company);
                }
            }
        }

        private IEnumerable<LegalEntityViewModel> ParseContent(string jsonContent)
        {
            var companies = JsonConvert.DeserializeObject<List<LegalEntityViewModel>>(jsonContent);
            return companies.Where(x => x.Location.Latitude != null && x.Location.Longitude != null);
        }

        private async void OpenMap()
        {
            await Navigation.PushAsync(new MapPage(new MapPageViewModel(Companies)));
        }

        private async void OpenFilter()
        {
            await PopupNavigation.Instance.PushAsync(new FiltersPopupView());
        }
    }
}
