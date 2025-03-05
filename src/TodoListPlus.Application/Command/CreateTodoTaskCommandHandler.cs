
namespace TodoListPlus.Application.Command;

public class CreateTodoTaskCommandHandler
    : IRequestHandler<CreateTodoTaskCommand, bool>
{
    private readonly ITodoTaskRepository _todoTaskRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<CreateTodoTaskCommandHandler> _logger;

    public async Task<bool> Handle(CreateTodoTaskCommand messgage, CancellationToken cancellationToken)
    {
        var todoTask = new TodoTask(messgage.UserId, messgage.Title, messgage.TaskContent, messgage.SubTime, messgage.Priority);

        _logger.LogInformation("Creating TodoTask - TodoTask: {@TodoTask}", todoTask);

        await _todoTaskRepository.AddAsync(todoTask);

        return await _todoTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
