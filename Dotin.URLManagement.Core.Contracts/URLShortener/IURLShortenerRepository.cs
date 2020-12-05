namespace Dotin.URLManagement.Core.Contracts.URLShortener
{
    using Dotin.URLManagement.Core.SharedDTO.URLShortener;
    using System.Threading.Tasks;

    public interface IURLShortenerRepository
    {
        Task<string> AddURL(URLShortenerDTO urlShortenerDTO);
    }
}
