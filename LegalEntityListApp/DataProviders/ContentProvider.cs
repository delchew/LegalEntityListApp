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
        private readonly string _baseRequestString = @"https://beta.marketing-logic.ru/mlead/api/v0/legals?page=";
        private readonly string _accessToken = @"&access-token=zCdJIdkcU5rGTG0lsngcrDGfsmEAV4Kz";

        public async Task<string> GetContentAsync(int pageNumber)
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
            if (!headers.TryGetValues("X-Pagination-Total-Count", out var totalCountValues))
                return string.Empty;

            var pagesCount = int.Parse(totalCountValues?.First());
            if (pageNumber > pagesCount)
                return string.Empty;

            return await response.Content.ReadAsStringAsync();
        }
    }
}
