namespace TodoListPlus.Domain.AggregatesModel.TodoTaskAggregate;

public interface ITodoTaskRepository : IRepository<TodoTask>
{
    Task<TodoTask> GetAsync(int todoTaskId);
    Task<TodoTask> AddAsync(TodoTask todoTask);
    void Update(TodoTask todoTask);
}
