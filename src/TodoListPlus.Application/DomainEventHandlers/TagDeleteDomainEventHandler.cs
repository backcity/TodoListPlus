namespace TodoListPlus.Application.DomainEventHandlers
{
    public class TagDeleteDomainEventHandler
          : INotificationHandler<TagDeleteDomainEvent>
    {
        private readonly ILogger _logger;
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TagDeleteDomainEventHandler(ILogger<TagDeleteDomainEventHandler> logger, ITodoTaskRepository todoTaskRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _todoTaskRepository = todoTaskRepository ?? throw new ArgumentNullException(nameof(todoTaskRepository));
        }

        public async Task Handle(TagDeleteDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var todoTasks = await _todoTaskRepository.GetTasksByTagId(domainEvent.tagId);
            if (todoTasks != null && todoTasks.Count > 0)
            {
                foreach (var todoTask in todoTasks)
                {
                    todoTask.RemoveTag(domainEvent.tagId);
                }
            }
            _todoTaskRepository.UpdateRange(todoTasks);
            await _todoTaskRepository.UnitOfWork.SaveChangesAsync();
            _logger.LogInformation($"{nameof(TagDeleteDomainEvent)}执行完成");
        }
    }
}
