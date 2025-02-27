namespace TodoListPlus.Domain.AggregatesModel.TodoTaskAggregate;

public class TaskTag 
{
    public int TodoTaskId { get; private set; }

    public int TagId { get; private set; }

    public DateTime CreatedAt { get; set; }

    public TodoTask TodoTask { get; private set; }

    public Tag Tag { get; private set; }

    public TaskTag(int todoTaskId, int tagId)
    {
        TodoTaskId = todoTaskId;
        TagId = tagId;
        CreatedAt = DateTime.Now;
    }
}
