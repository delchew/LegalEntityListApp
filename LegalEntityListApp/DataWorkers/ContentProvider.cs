using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LegalEntityListApp.DataWorkers;
using LegalEntityListApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContentProvider))]
namespace LegalEntityListApp.DataWorkers
{
    public class ContentProvider : IContentProvider
    {
        private IRequestStringBuilder requestStringBuilder = new SimpleFilterRequestBuilder();

        public async Task<string> GetContentAsync(int pageNumber, EntityFilter filter = null)
        {
            var requestString = requestStringBuilder.GetRequestString(pageNumber, filter);
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