using OpenCore.Application.Common.Interface;
using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.SharedKernel.Exceptions.Domain;

namespace OpenCore.Application.Tasks.Handler;

public sealed class DeleteByIdTaskHandler(ITaskRepository repo, IUnitOfWork unit)
{
    public async Task<Guid> HandleAsync(Guid id, CancellationToken ct)
    {
        TaskItem? task = await repo.GetAsync(id, ct);

        if (task is not null)
        {
            task.Delete();
            await unit.SaveChangesAsync(ct);
            return task.Id.Value;
        }

        throw new DomainNotFoundException();
    }
}
