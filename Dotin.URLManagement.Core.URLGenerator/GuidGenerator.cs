namespace Dotin.URLManagement.Core.URLGenerator
{
    using Dotin.URLManagement.Core.Contracts.URLShortener;
    using System;
    public class GuidGenerator : IURLGenerator<Guid>
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}
