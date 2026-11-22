using OpenCore.Application.Tasks.DTO;
using OpenCore.Application.Tasks.Query;
using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Criteria;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.SharedKernel.Exceptions;

namespace OpenCore.Application.Tasks.Handler;

public sealed class GetListTasksHandler(ITaskRepository repo)
{
    public async Task<List<TaskListItemDTO>> HandleAsync(GetListTasksQuery query, CancellationToken ct)
    {
        if (query.Limit < 1) {
            throw new InvalidArgumentException("Limit less then 1");
        }

        if (query.Offset < 0) {
            throw new InvalidArgumentException("Offset less then 0");
        }

        TaskSearchCriteria criteria = new(query.Limit, query.Offset);

        List<TaskItem> taskItems = await repo.GetListAsync(criteria, ct);

        return [.. taskItems.Select(el => new TaskListItemDTO(el.Id.Value, el.Title.Value, el.Status, el.CreatedAt))];
    }
}
