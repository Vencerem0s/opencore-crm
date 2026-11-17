using OpenCore.Domain.Tasks.Enum;
using OpenCore.Domain.Tasks.ValueObject;

namespace OpenCore.Domain.Tasks;

public sealed class TaskItem
{
    public TaskId Id { get; }
    public TaskTitle Title { get; }
    public TaskItemStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; }

    private TaskItem(TaskId id, TaskTitle title, DateTimeOffset createdAt, TaskItemStatus status)
    {
        Id = id;
        Title = title;
        Status = status;
        CreatedAt = createdAt;
    }

    public static TaskItem Create(TaskTitle title, DateTimeOffset createdAt)
    {
        return new TaskItem(
                TaskId.New(),
                title,
                createdAt,
                TaskItemStatus.Created
                );
    }

    public void Delete()
    {
        Status = TaskItemStatus.Deleted;
    }
}
