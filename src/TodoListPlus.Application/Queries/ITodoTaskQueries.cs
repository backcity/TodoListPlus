namespace TodoListPlus.Application.Queries;

public interface ITodoTaskQueries
{
    Task<TodoTask> GetTodoTaskAsync(int id);

    Task<IEnumerable<TodoTask>> GetTodoTasksFromUserAsync(string userId);
}
