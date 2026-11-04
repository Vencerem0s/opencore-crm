using OpenCore.SharedKernel.Exceptions.Domain;

namespace OpenCore.Domain.Tasks.ValueObject;

public readonly record struct TaskId
{
    public Guid Value { get; } = Guid.Empty;

    private TaskId(Guid id)
    {
        Value = id;
    }

    public static TaskId New()
    {
        return new TaskId(Guid.CreateVersion7());
    }

    public static TaskId Create(Guid id)
    {
        if (Guid.Empty == id) {
            throw new VOException("Task id can't be empty");
        }

        return new TaskId(id);
    }
}
