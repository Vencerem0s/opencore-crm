using Microsoft.AspNetCore.Mvc;
using OpenCore.Api.Contracts.V1.Tasks.Extension;
using OpenCore.Api.Contracts.V1.Tasks.Request;
using OpenCore.Api.Contracts.V1.Tasks.Response;
using OpenCore.Application.Tasks.Command;
using OpenCore.Application.Tasks.DTO;
using OpenCore.Application.Tasks.Handler;
using OpenCore.Application.Tasks.Query;
using OpenCore.SharedKernel.Exceptions;
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
    public async Task<IActionResult> Get(
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
                        taskDetails.Status.Label(),
                        taskDetails.CreatedAt
                       )
                    );
        }
        catch (DomainNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetListTasksRequest request,
        [FromServices] GetListTasksHandler handler,
        CancellationToken ct
    )
    {
        try
        {
            GetListTasksQuery query = new(request.Limit, request.Offset);

            List<TaskListItemDTO> tasksList = await handler.HandleAsync(query, ct);

            List<GetListTasksResponse> tasks = [.. tasksList.Select(
                el => new GetListTasksResponse(el.Id, el.Title, el.Status.Label(), el.CreatedAt)
            )];

            return Ok(new { items = tasks });
        }
        catch (InvalidArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        [FromServices] DeleteByIdTaskHandler handler,
        CancellationToken ct
    )
    {
        try
        {
            return Ok(new DeleteTaskResponse(await handler.HandleAsync(id, ct)));

        }
        catch (DomainNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
