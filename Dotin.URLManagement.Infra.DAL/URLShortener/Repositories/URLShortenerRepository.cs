namespace Dotin.URLManagement.Infra.DAL.URLShortener.Repositories
{
    using Dotin.URLManagement.Core.Contracts.URLShortener;
    using Dotin.URLManagement.Core.SharedDTO.URLShortener;
    using Dotin.URLManagement.Infra.DAL.DatabaseContexts;
    using Dotin.URLManagement.Infra.DAL.URLShortener.Entities;
    using System.Threading.Tasks;

    public class URLShortenerRepository : IURLShortenerRepository
    {
        private readonly URLManagementDbContext urlManagementDbContext;

        public URLShortenerRepository(URLManagementDbContext urlManagementDbContext)
        {
            this.urlManagementDbContext = urlManagementDbContext;
        }
        public async Task<string> AddURL(URLShortenerDTO urlShortenerDTO)
        {
            urlManagementDbContext.ShrotenerURLs.Add(
                new ShrotenerURL {
                    ConvertedURL = urlShortenerDTO.ConvertedURL,
                    MainURL = urlShortenerDTO.MainURL });
            await urlManagementDbContext.SaveChangesAsync();
            return await Task.FromResult(urlShortenerDTO.ConvertedURL);
        }
    }
}
