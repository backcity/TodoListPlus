namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

public interface ITaskTagRepository : IRepository<TaskTag>
{
    Task<TaskTag> AddAsync(TaskTag taskTag);
    void Update(TaskTag taskTag);
    void Delete(TaskTag taskTag);
    Task<TaskTag> GetAsync(int taskTagId);
}
