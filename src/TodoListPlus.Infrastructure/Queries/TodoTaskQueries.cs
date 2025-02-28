using TodoListPlus.Application.Queries;

namespace TodoListPlus.Infrastructure.Query;

public class TodoTaskQueries(TodoListPlusDbContext context)
    : ITodoTaskQueries
{

    public async Task<Application.Queries.TodoTask> GetTodoTaskAsync(int id)
    {
        var todoTask = await context.TodoTasks
             .Include(t => t.TaskTags)
             .ThenInclude(tt => tt.Tag)
             .FirstOrDefaultAsync(t => t.Id == id);

        if (todoTask is null)
            throw new KeyNotFoundException();

        return new Application.Queries.TodoTask
        {
            TaskNumber = todoTask.Id,
            Date = todoTask.SubTime,
            IsDownOver = todoTask.TodoTaskStatus.ToString(),
            Priority = todoTask.Priority.ToString(),
            TaskContent = todoTask.TaskContent,
            Title = todoTask.Title,
            Tags = todoTask.TaskTags.Select(t => new Application.Queries.Tag
            {
                HexColor = t.Tag.TagColor.Value,
                Name = t.Tag.Name,
            }).ToList()
        };
    }

    public async Task<IEnumerable<Application.Queries.TodoTask>> GetTodoTasksFromUserAsync(string userId)
    {
        return await context.TodoTasks
            .Where(t => t.IdentityId == userId)
            .Include(t => t.TaskTags)
            .ThenInclude(tt => tt.Tag)
            .Select(t => new Application.Queries.TodoTask
            {
                TaskNumber = t.Id,
                Date = t.SubTime,
                IsDownOver = t.TodoTaskStatus.ToString(),
                Priority = t.Priority.ToString(),
                TaskContent = t.TaskContent,
                Title = t.Title,
                Tags = t.TaskTags.Select(tt => new Application.Queries.Tag
                {
                    HexColor = tt.Tag.TagColor.Value,
                    Name = tt.Tag.Name,
                }).ToList()

            }).ToListAsync();
    }
}
