using System.ComponentModel.DataAnnotations;
using TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

namespace TodoListPlus.Domain.AggregatesModel.TodoTaskAggregate;

/// <summary>
/// 待办任务聚合根
/// </summary>
public class TodoTask
     : Entity, IAggregateRoot
{
    public TodoTask()
    {
        TaskTags = new List<TaskTag>();
    }

    /// <summary>
    /// 任务标题
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// 任务内容描述
    /// </summary>
    public string TaskContent { get; private set; }

    /// <summary>
    /// 订阅提醒时间
    /// </summary>
    public DateTime SubTime { get; private set; }

    /// <summary>
    /// 任务优先级
    /// </summary>
    public Priority Priority { get; private set; }

    [Required]
    public string IdentityId { get; private set; }

    public List<TaskTag> TaskTags { get; private set; }

    public TodoTaskStatus TodoTaskStatus { get; private set; }

    public TodoTask(string identityId, string title, string taskContent, DateTime subTime, Priority priority)
        : this()
    {
        IdentityId = !string.IsNullOrWhiteSpace(identityId) ? identityId : throw new TodoListPlusDomainException(nameof(identityId));
        Title = !string.IsNullOrWhiteSpace(title) ? title : throw new TodoListPlusDomainException(nameof(title));
        TaskContent = !string.IsNullOrWhiteSpace(taskContent) ? taskContent : throw new TodoListPlusDomainException(nameof(taskContent));

        if (subTime < DateTime.Now)
        {
            throw new TodoListPlusDomainException(nameof(subTime));
        }
        SubTime = subTime;

        Priority = priority;
    }

    public void RemoveTag(int tagId)
    {
        var taskTag = TaskTags
            .Where(p => p.TagId == tagId)
            .SingleOrDefault();

        if (taskTag != null)
        {
            TaskTags.Remove(taskTag);
        }
    }

    public void TaskOverDown()
    {
        if (TodoTaskStatus != TodoTaskStatus.未完成)
        {
            throw new TodoListPlusDomainException($"任务的状态不能从{TodoTaskStatus}转变为{TodoTaskStatus.已完成}");
        }

        TodoTaskStatus = TodoTaskStatus.已完成;
    }

    public void AddTag(TaskTag taskTag)
    {
        var existTag = TaskTags.SingleOrDefault(t => t.TagId == taskTag.TagId);
        if (existTag != null)
        {
            return;
        }
        TaskTags.Add(taskTag);
    }
}
