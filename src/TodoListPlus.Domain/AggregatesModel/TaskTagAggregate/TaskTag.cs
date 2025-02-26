namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

/// <summary>
/// 领域任务标签
/// </summary>
public class TaskTag
    : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    public TagColor TagColor { get; private set; }

    public TaskTag(string name, string tagColor)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new TodoListPlusException($"{nameof(name)}");
        TagColor = new TagColor(tagColor);
    }

    public void Delete()
    {
        AddDomainEvent(new TagDeleteEvent(Id));
    }
}
