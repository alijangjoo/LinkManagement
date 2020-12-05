namespace Dotin.URLManagement.Infra.DAL.URLViewer.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Dotin.URLManagement.Core.Contracts.URLViewer;
    using Dotin.URLManagement.Infra.DAL.DatabaseContexts;
    using Dotin.URLManagement.Infra.DAL.URLViewer.Entities;

    public class URLViewerRepository : IURLViewerRepository
    {
        private readonly URLManagementDbContext urlManagementDbContext;

        public URLViewerRepository(URLManagementDbContext urlManagementDbContext)
        {
            this.urlManagementDbContext = urlManagementDbContext;
        }

        public async Task<bool> AddInfo()
        {
            urlManagementDbContext.URLViewerInfo.Add(new URLViewerInfo { ViewCount = 0 });
            await urlManagementDbContext.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public Task<string> GetURL(string shortenerURL)
        {            
            string mainURL = urlManagementDbContext.ShrotenerURLs.Where(c => c.ConvertedURL.ToLower() == shortenerURL.ToLower()).Select(c => c.MainURL).FirstOrDefault();
            return Task.FromResult(mainURL);
        }

        public async Task<bool> IncreementViewerLogInfo()
        {
            bool exists = false;
            var selectedRow = urlManagementDbContext.URLViewerInfo.FirstOrDefault();
            if (selectedRow != null)
            {
                selectedRow.ViewCount += 1;
                await urlManagementDbContext.SaveChangesAsync();
                exists = true;
            }
            return await Task.FromResult(exists);
        }

        public Task<bool> ViewerLogRowInfoExists()
        {
            bool exists = false;
            var selectedRow = urlManagementDbContext.URLViewerInfo.FirstOrDefault();
            if (selectedRow != null)
            {
                exists = true;
            }
            return Task.FromResult(exists);
        }
    }
}
