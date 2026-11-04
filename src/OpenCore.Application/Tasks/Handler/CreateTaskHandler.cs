using OpenCore.Application.Common.Interface;
using OpenCore.Application.Tasks.Command;
using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.Domain.Tasks.ValueObject;

namespace OpenCore.Application.Tasks.Handler;

public sealed class CreateTaskHandler(ITaskRepository repo, TimeProvider time, IUnitOfWork unitOfWork)
{
    public async Task<Guid> HandleAsync(CreateTaskCommand command, CancellationToken ct)
    {
        TaskTitle title = TaskTitle.Create(command.Title);
        TaskItem taskItem = TaskItem.Create(title, time.GetUtcNow());
        await repo.AddAsync(taskItem, ct);
        await unitOfWork.SaveChangesAsync(ct);
        return taskItem.Id.Value;
    }
}
