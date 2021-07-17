using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using LegalEntityListApp.Models;
using System.Collections.Generic;
using LegalEntityListApp.DataProviders;
using Xamarin.Forms;

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
            var jArray = JArray.Parse(jsonContent);
            foreach (var item in jArray)
            {
                var company = new LegalEntityViewModel();

                if (double.TryParse(item.SelectToken(@"location.latitude")?.ToString(), out double latitude) &&
                    double.TryParse(item.SelectToken(@"location.longitude")?.ToString(), out double longitude))
                {
                    company.Location = new Location
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    };
                }
                else continue;

                if (int.TryParse(item.SelectToken(@"id")?.ToString(), out int id))
                {
                    company.Id = id;
                }

                if (DateTime.TryParse(item.SelectToken(@"registration_date")?.ToString(), out DateTime date))
                {
                    company.RegistrationDate = date;
                }

                if (double.TryParse(item.SelectToken(@"authorized_capital")?.ToString(), out double capital))
                {
                    company.AuthorizedCapital = capital;
                }

                company.ShortName = item.SelectToken(@"$.short_name")?.ToString();
                company.FullName = item.SelectToken(@"full_name")?.ToString();
                company.Address = item.SelectToken(@"$.address")?.ToString();
                company.Psrn = item.SelectToken(@"$.psrn")?.ToString();
                company.Tin = item.SelectToken(@"$.tin")?.ToString();
                company.Rrc = item.SelectToken(@"$.rrc")?.ToString();
                company.LegalForm = item.SelectToken(@"$.legal_form")?.ToString();
                company.OwnershipForm = item.SelectToken(@"$.ownership_form")?.ToString();
                company.Industry = item.SelectToken(@"$.industry")?.ToString();
                company.HeadPosition = item.SelectToken(@"$.head_position")?.ToString();
                company.HeadFullName = item.SelectToken(@"$.head_full_name")?.ToString();
                company.HeadItn = item.SelectToken(@"$.head_itn")?.ToString();
                company.OrganizationStatus = item.SelectToken(@"$.organization_status")?.ToString();

                yield return company;
            }
        }
    }
}
