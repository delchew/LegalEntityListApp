using LegalEntityListApp.Models;

namespace LegalEntityListApp.DataWorkers
{
    public interface IRequestStringBuilder
    {
        string GetRequestString(int pageNumber = 1, EntityFilter filter = null);
    }
}
