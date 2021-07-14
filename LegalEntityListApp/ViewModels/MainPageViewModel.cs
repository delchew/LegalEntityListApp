using System;
using System.Net;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using LegalEntityListApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LegalEntityListApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly StringBuilder _requestStringBuilder = new StringBuilder();
        private readonly string _baseRequestString = @"https://beta.marketing-logic.ru/mlead/api/v0/legals?page=";
        private readonly string _accessToken = @"&access-token=zCdJIdkcU5rGTG0lsngcrDGfsmEAV4Kz";
        private int _currentPageNumber = 0;

        public ObservableCollection<LegalEntityViewModel> Companies { get; private set; }

        public MainPageViewModel()
        {
            Companies = new ObservableCollection<LegalEntityViewModel>();
        }

        public async void GetCompanies()
        {
            var jsonString = await GetContent(++_currentPageNumber);
            if (!string.IsNullOrEmpty(jsonString))
            {
                var companies = ParseContent(jsonString);
                foreach (var company in companies)
                {
                    Companies.Add(company);
                }
            }
        }

        private async Task<string> GetContent(int pageNumber)
        {
            var requestString = _requestStringBuilder.Clear()
                                                     .Append(_baseRequestString)
                                                     .Append(pageNumber)
                                                     .Append(_accessToken)
                                                     .ToString();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(requestString),
                Method = HttpMethod.Get
            };
            request.Headers.Add("VersionCode", "177");
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            if (response.StatusCode != HttpStatusCode.OK)
                return string.Empty;

            var headers = response.Headers;
            if (!headers.TryGetValues("X-Pagination-Total-Count", out var values))
                return string.Empty;

            var pagesCount = int.Parse(values?.First());
            if (_currentPageNumber > pagesCount)
                return string.Empty;

            return await response.Content.ReadAsStringAsync();
        }

        private IEnumerable<LegalEntityViewModel> ParseContent(string jsonContent)
        {
            var jArray = JArray.Parse(jsonContent);
            foreach (var item in jArray)
            {
                var company = new LegalEntityViewModel();

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

                if (double.TryParse(item.SelectToken(@"location.latitude")?.ToString(), out double latitude) &&
                    double.TryParse(item.SelectToken(@"location.longitude")?.ToString(), out double longitude))
                {
                    company.Location = new Location
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    };
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
