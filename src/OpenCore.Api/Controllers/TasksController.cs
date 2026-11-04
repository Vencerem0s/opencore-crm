using Microsoft.AspNetCore.Mvc;
using OpenCore.Api.Contracts.Tasks;
using OpenCore.Application.Tasks.Command;
using OpenCore.Application.Tasks.Handler;

namespace OpenCore.Api.Controllers;

[ApiController]
[Route("tasks")]
public sealed class TasksController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
            CreateTaskRequest request,
            [FromServices] CreateTaskHandler handler,
            CancellationToken ct
    )
    {
        CreateTaskCommand command = new(request.Title);

        Guid id = await handler.HandleAsync(command, ct);

        return Created($"/tasks/{id}", new CreateTaskResponse(id));
    }
}
