using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LegalEntityListApp.DataProviders;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContentProvider))]
namespace LegalEntityListApp.DataProviders
{
    public class ContentProvider : IContentProvider
    {
        private readonly StringBuilder _requestStringBuilder = new StringBuilder();
        private readonly string _baseRequestString = @"https://beta.marketing-logic.ru/mlead/api/v0/legals";
        private readonly (string name, string value) _accessToken = (@"access-token", @"zCdJIdkcU5rGTG0lsngcrDGfsmEAV4Kz");

        public async Task<string> GetContentAsync(int pageNumber)
        {
            var requestString = GenerateRequestString(_accessToken, ("page", pageNumber.ToString()));
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
            if (!headers.TryGetValues("X-Pagination-Total-Count", out var totalCountValues))
                return string.Empty;

            var pagesCount = int.Parse(totalCountValues?.First());
            if (pageNumber > pagesCount)
                return string.Empty;

            return await response.Content.ReadAsStringAsync();
        }

        private string GenerateRequestString(params (string name, string value) [] requestParams)
        {
            _requestStringBuilder.Clear().Append(_baseRequestString);
            if(requestParams != null && requestParams.Length > 0)
            {
                for (int i = 0; i < requestParams.Length; i++)
                {
                    _requestStringBuilder.Append(i == 0 ? "?" : "&");
                    _requestStringBuilder.Append($"{requestParams[i].name}={requestParams[i].value}");
                }
            }
            return _requestStringBuilder.ToString();
        }
    }
}
