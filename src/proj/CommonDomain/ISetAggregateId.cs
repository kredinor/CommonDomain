namespace CommonDomain
{
    using System;

    internal interface ISetAggregateId
    {
        void SetAggregateId(Guid aggregateId);
    }
}