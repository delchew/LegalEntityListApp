using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Input;
using LegalEntityListApp.Views;
using Rg.Plugins.Popup.Services;
using LegalEntityListApp.Models;
using LegalEntityListApp.DataWorkers;

namespace LegalEntityListApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IContentProvider _contentProvider;
        private int _currentPageNumber = 0;
        private FiltersPopupView _filtersPopupView;
        public FiltersPopupView FiltersPopupView
        {
            get
            {
                if (_filtersPopupView == null)
                {
                    var viewModel = new FiltersPopupViewModel(GetFilteredCompanies);
                    _filtersPopupView = new FiltersPopupView(viewModel);
                }
                return _filtersPopupView;
            }
        }
        public ObservableCollection<LegalEntityViewModel> Companies { get; private set; }
        public INavigation Navigation { get; set; }
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
            AddParsedCompanies(jsonString);
        }

        public async void GetFilteredCompanies(EntityFilter filter)
        {
            var jsonString = await _contentProvider.GetContentAsync(1, filter);
            Companies.Clear();
            AddParsedCompanies(jsonString);
        }

        private void AddParsedCompanies(string jsonString)
        {
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
            await PopupNavigation.Instance.PushAsync(FiltersPopupView);
        }
    }
}
