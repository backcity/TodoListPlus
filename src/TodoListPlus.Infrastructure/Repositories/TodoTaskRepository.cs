namespace TodoListPlus.Infrastructure.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly TodoListPlusDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public TodoTaskRepository(TodoListPlusDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<TodoTask> AddAsync(TodoTask todoTask)
    {
        return (await _context.TodoTasks.AddAsync(todoTask)).Entity;
    }

    public async Task<TodoTask> GetAsync(int todoTaskId)
    {
        var todoTask = await _context.TodoTasks.FindAsync(todoTaskId);

        return todoTask;
    }

    public void Update(TodoTask todoTask)
    {
        _context.Entry(todoTask).State = EntityState.Modified;
    }
}
