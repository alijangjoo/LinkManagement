namespace Dotin.URLManagement.Core.Contracts.URLShortener
{
    using System.Threading.Tasks;

    public interface IURLShortenerService
    {
        public Task<string> AddURL(string inputURL);
    }
}
