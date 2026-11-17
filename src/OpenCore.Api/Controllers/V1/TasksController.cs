using Microsoft.AspNetCore.Mvc;
using OpenCore.Api.Contracts.V1.Tasks;
using OpenCore.Application.Tasks.Command;
using OpenCore.Application.Tasks.DTO;
using OpenCore.Application.Tasks.Handler;
using OpenCore.SharedKernel.Exceptions.Domain;

namespace OpenCore.Api.Controllers.V1;

[ApiController]
[Route("api/v1/tasks")]
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

        return Created($"/api/v1/tasks/{id}", new CreateTaskResponse(id));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
         Guid id,
         [FromServices] GetByIdTaskHandler handler,
         CancellationToken ct
    )
    {
        try
        {
            TaskDetailsDTO taskDetails = await handler.HandleAsync(id, ct);

            return Ok(
                    new GetByIdTaskResponse(
                        taskDetails.Id,
                        taskDetails.Title,
                        taskDetails.CreatedAt
                       )
                    );
        }
        catch (DomainNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
