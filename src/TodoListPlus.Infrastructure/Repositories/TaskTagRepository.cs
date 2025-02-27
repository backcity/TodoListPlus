namespace TodoListPlus.Infrastructure.Repositories;

public class TaskTagRepository : ITaskTagRepository
{
    public IUnitOfWork UnitOfWork => _context;

    private readonly TodoListPlusDbContext _context;

    public TaskTagRepository(TodoListPlusDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Tag> AddAsync(Tag taskTag)
    {
        return (await _context.Tags.AddAsync(taskTag)).Entity;
    }

    public void Delete(Tag taskTag)
    {
        _context.Entry(taskTag).State = EntityState.Deleted;
    }

    public async Task<Tag> GetAsync(int taskTagId)
    {
        var taskTag = await _context.Tags.FindAsync(taskTagId);
        return taskTag;
    }

    public void Update(Tag taskTag)
    {
        _context.Entry(taskTag).State = EntityState.Modified;
    }
}
