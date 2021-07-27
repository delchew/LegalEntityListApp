using LegalEntityListApp.Models;

namespace LegalEntityListApp.DataWorkers
{
    public interface IRequestStringBuilder
    {
        string BaseRequestString { get; set; }

        string AccessTokenString { get; set; }

        string GetRequestString(int pageNumber = 1, EntityFilter filter = null);
    }
}
