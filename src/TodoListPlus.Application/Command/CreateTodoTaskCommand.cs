using System.Runtime.Serialization;

namespace TodoListPlus.Application.Command;

[DataContract]
public class CreateTodoTaskCommand
   : IRequest<bool>
{
    [DataMember]
    private readonly List<TaskTagDto> _taskTagItems;
    [DataMember]
    public string UserId { get; private set; }
    [DataMember]
    public string UserName { get; private set; }
    [DataMember]
    public string Title { get; private set; }
    [DataMember]
    public string TaskContent { get; private set; }
    [DataMember]
    public DateTime SubTime { get; private set; }
    [DataMember]
    public Priority Priority { get; private set; }
    [DataMember]
    public IEnumerable<TaskTagDto> TaskTagItems => _taskTagItems;
}

public record TaskTagDto
{
    public int TagId { get; init; }
}






