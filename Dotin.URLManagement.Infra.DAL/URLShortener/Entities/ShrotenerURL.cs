namespace Dotin.URLManagement.Infra.DAL.URLShortener.Entities
{
    public class ShrotenerURL
    {
        public long Id { get; set; }
        public string ConvertedURL { get; set; }
        public string MainURL { get; set; }
    }
}
