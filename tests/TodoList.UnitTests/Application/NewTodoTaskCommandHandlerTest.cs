using NSubstitute;
using TodoListPlus.Application.Contracts;

namespace TodoList.UnitTests.Application;

public class NewTodoTaskCommandHandlerTest
{
    private readonly ITodoTaskRepository _todoTaskRepositoryMock;
    private readonly IMediator _mediator;
    private readonly ILoggedInUserService _loggedInUserServiceMock;

    public NewTodoTaskCommandHandlerTest()
    {
        _todoTaskRepositoryMock = Substitute.For<ITodoTaskRepository>();
        _mediator = Substitute.For<IMediator>();
        _loggedInUserServiceMock = Substitute.For<ILoggedInUserService>();
    }


}
 