namespace CommonDomain.Core
{
	using System;
	using System.Collections.Generic;

	public class RegistrationEventRouter : IRouteEvents, IProvideRoutedEventTypes
	{
	    private readonly bool _shouldThrowOnHandlerNotFound;
	    private readonly IDictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
		private IAggregate registered;

	    public RegistrationEventRouter() : this(true)
	    {
	    }

	    public RegistrationEventRouter(bool shouldThrowOnHandlerNotFound)
	    {
	        _shouldThrowOnHandlerNotFound = shouldThrowOnHandlerNotFound;
	    }

	    public virtual void Register<T>(Action<T> handler)
		{
			this.handlers[typeof(T)] = @event => handler((T)@event);
		}
		public virtual void Register(IAggregate aggregate)
		{
			if (aggregate == null)
				throw new ArgumentNullException("aggregate");

			this.registered = aggregate;
		}

		public virtual void Dispatch(object eventMessage)
		{
			Action<object> handler;

			if (!this.handlers.TryGetValue(eventMessage.GetType(), out handler))
			{
                if (_shouldThrowOnHandlerNotFound)
			        this.registered.ThrowHandlerNotFound(eventMessage);
			}
		    else
			{
			    handler(eventMessage);
			}
		}

	    public IEnumerable<Type> GetRoutedEventTypes()
	    {
	        return handlers.Keys;
	    }
	}
}