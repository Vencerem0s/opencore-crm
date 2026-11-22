using OpenCore.Domain.Tasks.Criteria;

namespace OpenCore.Domain.Tasks.Repository;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task, CancellationToken ct);
    Task<TaskItem?> GetAsync(Guid id, CancellationToken ct);
    Task<List<TaskItem>> GetListAsync(TaskSearchCriteria criteria, CancellationToken ct);
}
