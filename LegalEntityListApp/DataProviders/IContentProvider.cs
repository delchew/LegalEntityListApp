using System.Threading.Tasks;

namespace LegalEntityListApp.DataProviders
{
    public interface IContentProvider
    {
        Task<string> GetContentAsync (int pageNumber);
    }
}
