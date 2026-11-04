using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Repository;

namespace OpenCore.Infrastructure.Persistence.Tasks.Repository;

public sealed class TaskRepository(OpenCoreDbContext context) : ITaskRepository
{
    public Task AddAsync(TaskItem task, CancellationToken ct)
    {
        context.Tasks.Add(task);
        return Task.CompletedTask;
    }
}
