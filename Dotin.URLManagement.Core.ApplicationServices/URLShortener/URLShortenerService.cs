namespace Dotin.URLManagement.Core.ApplicationServices.URLShortener
{
    using Dotin.URLManagement.Core.Contracts.URLShortener;
    using Dotin.URLManagement.Core.SharedDTO.URLShortener;
    using System;
    using System.Threading.Tasks;

    public class URLShortenerService : IURLShortenerService
    {
        private readonly IURLShortenerRepository urlShortenerRepository;
        private readonly IURLGenerator<Guid> urlGenerator;

        public URLShortenerService(IURLShortenerRepository urlShortenerRepository, IURLGenerator<Guid> urlGenerator)
        {
            this.urlShortenerRepository = urlShortenerRepository;
            this.urlGenerator = urlGenerator;
        }
        public async Task<string> AddURL(string inputURL)
        {
            string shortenerURL = urlGenerator.Generate().ToString();
            if (string.IsNullOrEmpty(shortenerURL))
            {
                throw new Exception("URL Generator not work");
            }
            string generatedURL = await urlShortenerRepository.AddURL(new URLShortenerDTO { ConvertedURL = shortenerURL, MainURL = inputURL});
            return await Task.FromResult(generatedURL);
        }
    }
}
