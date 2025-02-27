namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

public interface ITaskTagRepository : IRepository<Tag>
{
    Task<Tag> AddAsync(Tag taskTag);
    void Update(Tag taskTag);
    void Delete(Tag taskTag);
    Task<Tag> GetAsync(int taskTagId);
}
