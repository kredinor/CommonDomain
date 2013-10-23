namespace CommonDomain
{
	using System;

	public interface IRouteEvents
	{
		void Register<T>(Action<T> handler);
		void Register(IAggregate aggregate);

		bool Dispatch(object eventMessage);
	}
}