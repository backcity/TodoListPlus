

namespace TodoListPlus.Domain.Events;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
public record class TagDeleteEvent(int Id) : INotification;
