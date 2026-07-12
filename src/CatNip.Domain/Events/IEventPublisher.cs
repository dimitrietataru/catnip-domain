namespace CatNip.Domain.Events;

public interface IEventPublisher
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellation = default)
        where TMessage : class, IEvent;
}
