

namespace TodoListPlus.Domain.Events;

/// <summary>
/// 
/// </summary>
/// <param name="tagId"></param>
public record class TagDeleteDomainEvent(int tagId) : INotification;
