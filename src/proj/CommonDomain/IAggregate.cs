namespace CommonDomain
{
	using System;
	using System.Collections;

	public interface IAggregate
	{
		Guid Id { get; }
		int Version { get; }

		bool ApplyEvent(object @event);
		ICollection GetUncommittedEvents();
		void ClearUncommittedEvents();

		IMemento GetSnapshot();
	}
}