

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

        if (todoTask != null)
        {
            await _context.Entry(todoTask)
                .Collection(t => t.TaskTags)
                .LoadAsync();
        }

        return todoTask;
    }

    public void Update(TodoTask todoTask)
    {
        _context.Entry(todoTask).State = EntityState.Modified;
    }

    public async Task<List<TodoTask>> GetTasksByTagId(int tagId)
    {

        return await _context.TaskTags
            .Where(t => t.TagId == tagId)
            .Include(t => t.TodoTask)
            .Select(t => t.TodoTask)
            .Distinct()
            .ToListAsync();
    }

    public void UpdateRange(ICollection<TodoTask> todoTasks)
    {
        foreach (var item in todoTasks)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
