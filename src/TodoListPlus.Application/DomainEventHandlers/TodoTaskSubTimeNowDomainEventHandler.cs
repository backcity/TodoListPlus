
namespace TodoListPlus.Application.DomainEventHandlers
{
    public class TodoTaskSubTimeNowDomainEventHandler
        : INotificationHandler<TodoTaskSubTimeNowDomainEvent>
    {


        public Task Handle(TodoTaskSubTimeNowDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
