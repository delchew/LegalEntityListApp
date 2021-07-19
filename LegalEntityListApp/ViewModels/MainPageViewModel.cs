using System.Collections.ObjectModel;
using System.Collections.Generic;
using LegalEntityListApp.DataProviders;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;

namespace LegalEntityListApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IContentProvider _contentProvider;
        private int _currentPageNumber = 0;
        public ObservableCollection<LegalEntityViewModel> Companies { get; private set; }

        public MainPageViewModel()
        {
            Companies = new ObservableCollection<LegalEntityViewModel>();
            _contentProvider = DependencyService.Get<IContentProvider>();
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
    }
}
