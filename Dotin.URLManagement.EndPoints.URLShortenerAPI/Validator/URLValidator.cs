namespace Dotin.URLManagement.EndPoints.URLShortenerAPI.Validator
{
    using System;
    public class URLValidator
    {
        public static bool UrlIsValid(string url)
        {
            Uri uriResult;
            bool isValid = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return isValid;
        }
    }
}
