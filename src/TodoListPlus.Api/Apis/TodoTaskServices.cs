using MediatR;

namespace TodoListPlus.Api.Apis
{
    public class TodoTaskServices(
        IMediator mediator,
        ITodoTaskQueries queries,
        ILoggedInUserService identityService,
        ILogger<TodoTaskServices> logger)
    {
        public IMediator Mediator { get; set; } = mediator;
        public ILogger<TodoTaskServices> Logger { get; } = logger;
        public ITodoTaskQueries Queries { get; } = queries;
        public ILoggedInUserService IdentityService { get; } = identityService;

    }
}
