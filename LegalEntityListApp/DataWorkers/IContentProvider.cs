using System.Threading.Tasks;
using LegalEntityListApp.Models;

namespace LegalEntityListApp.DataWorkers
{
    public interface IContentProvider
    {
        Task<string> GetContentAsync (int pageNumber, EntityFilter filter = null);
    }
}
