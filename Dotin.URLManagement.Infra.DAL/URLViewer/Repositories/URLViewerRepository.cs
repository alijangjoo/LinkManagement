namespace Dotin.URLManagement.Infra.DAL.URLViewer.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Dotin.URLManagement.Core.Contracts.URLViewer;
    using Dotin.URLManagement.Infra.DAL.DatabaseContexts;

    public class URLViewerRepository : IURLViewerRepository
    {
        private readonly URLManagementDbContext urlManagementDbContext;

        public URLViewerRepository(URLManagementDbContext urlManagementDbContext)
        {
            this.urlManagementDbContext = urlManagementDbContext;
        }
        public Task<string> GetURL(string shortenerURL)
        {
            string mainURL = urlManagementDbContext.ShrotenerURLs.Where(c => c.ConvertedURL.ToLower() == shortenerURL.ToLower()).Select(c => c.MainURL).FirstOrDefault();
            return Task.FromResult(mainURL);
        }
    }
}
