namespace Dotin.URLManagement.Core.Contracts.URLViewer
{
    using System.Threading.Tasks;
    public interface IURLViewerService
    {
        Task<string> GetMainURL(string shortenerURL);
    }
}
