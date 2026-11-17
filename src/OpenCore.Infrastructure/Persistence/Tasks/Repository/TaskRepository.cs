using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.Domain.Tasks.ValueObject;

namespace OpenCore.Infrastructure.Persistence.Tasks.Repository;

internal sealed class TaskRepository(OpenCoreDbContext context) : ITaskRepository
{
    public Task AddAsync(TaskItem task, CancellationToken ct)
    {
        context.Tasks.Add(task);
        return Task.CompletedTask;
    }

    public async Task<TaskItem?> GetAsync(Guid id, CancellationToken ct)
    {
        TaskId taskId = TaskId.Create(id);
        return await context.Tasks.FindAsync([taskId], ct);
    }
}
