namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

/// <summary>
/// 领域任务标签
/// </summary>
public class Tag
    : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    public TagColor TagColor { get; private set; }



    public Tag(string name, string tagColor)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new TodoListPlusDomainException($"{nameof(name)}");
        TagColor = new TagColor(tagColor);
    }

    public Tag()
    {
    }

    public void Delete()
    {
        AddDomainEvent(new TagDeleteDomainEvent(Id));
    }
}
