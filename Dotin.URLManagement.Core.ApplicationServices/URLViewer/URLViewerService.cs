namespace Dotin.URLManagement.Core.ApplicationServices.URLViewer
{
    using System.Threading.Tasks;
    using Dotin.URLManagement.Core.Contracts.URLViewer;
    public class URLViewerService : IURLViewerService
    {
        private readonly IURLViewerRepository urlViewerRepository;

        public URLViewerService(IURLViewerRepository urlViewerRepository)
        {
            this.urlViewerRepository = urlViewerRepository;
        }
        public async Task<string> GetMainURL(string shortenerURL)
        {
            string mainURL = await urlViewerRepository.GetURL(shortenerURL);
            return await Task.FromResult(mainURL);
        }
    }
}
