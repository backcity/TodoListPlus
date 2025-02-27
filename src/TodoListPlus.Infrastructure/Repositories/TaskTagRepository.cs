namespace TodoListPlus.Infrastructure.Repositories;

public class TaskTagRepository : ITaskTagRepository
{
    public IUnitOfWork UnitOfWork => _context;

    private readonly TodoListPlusDbContext _context;

    public TaskTagRepository(TodoListPlusDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<TaskTag> AddAsync(TaskTag taskTag)
    {
        return (await _context.TaskTags.AddAsync(taskTag)).Entity;
    }

    public void Delete(TaskTag taskTag)
    {
        _context.Entry(taskTag).State = EntityState.Deleted;
    }

    public async Task<TaskTag> GetAsync(int taskTagId)
    {
        var taskTag = await _context.TaskTags.FindAsync(taskTagId);
        return taskTag;
    }

    public void Update(TaskTag taskTag)
    {
        _context.Entry(taskTag).State = EntityState.Modified;
    }
}
