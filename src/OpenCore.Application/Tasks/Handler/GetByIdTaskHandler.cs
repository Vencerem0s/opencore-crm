using OpenCore.Application.Tasks.DTO;
using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.SharedKernel.Exceptions.Domain;

namespace OpenCore.Application.Tasks.Handler;

public sealed class GetByIdTaskHandler(ITaskRepository repo)
{
    public async Task<TaskDetailsDTO> HandleAsync(Guid id, CancellationToken ct)
    {
        TaskItem? task = await repo.GetAsync(id, ct);

        if (task is not null)
        {
            return new TaskDetailsDTO(task.Id.Value, task.Title.Value, task.Status, task.CreatedAt);
        }

        throw new DomainNotFoundException();
    }
}
