namespace CommonDomain.Core
{
    using System;
    using System.Collections.Generic;

    public interface IProvideRoutedEventTypes
    {
        IEnumerable<Type> GetRoutedEventTypes();
    }
}