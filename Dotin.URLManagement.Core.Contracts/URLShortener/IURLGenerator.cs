namespace Dotin.URLManagement.Core.Contracts.URLShortener
{
    using System;
    public interface IURLGenerator<T>
    {
        public T Generate();
    }
}
