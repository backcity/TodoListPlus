﻿

namespace TodoListPlus.Domain.Events;

/// <summary>
/// 任务截止时间到提醒 领域事件
/// </summary>
public record class TodoTaskSubTimeNowEvent(
    int userId,
    int taskId) : INotification;
