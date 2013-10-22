namespace CommonDomain.Core
{
    public interface IHaveEventRouter
    {
        IRouteEvents EventRouter { get; }
    }
}