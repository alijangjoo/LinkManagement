namespace Dotin.URLManagement.Core.Contracts.URLViewer
{
    using System.Threading.Tasks;

    public interface IURLViewerRepository
    {
        Task<string> GetURL(string shortenerURL);
        Task<bool> ViewerLogRowInfoExists();
        Task<bool> IncreementViewerLogInfo();
        Task<bool> AddInfo();
    }
}
