using OpenCore.Domain.Tasks.ValueObject;

namespace OpenCore.Domain.Tasks;

public sealed class TaskItem
{
    public TaskId Id { get; }
    public TaskTitle Title { get; }
    public DateTimeOffset CreatedAt { get; }

    private TaskItem(TaskId id, TaskTitle title, DateTimeOffset createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }

    public static TaskItem Create(TaskTitle title, DateTimeOffset createdAt)
    {
        return new TaskItem(
                TaskId.New(),
                title,
                createdAt
                );
    }
}
