namespace OpenCore.Domain.Tasks.Repository;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task, CancellationToken ct);
}
