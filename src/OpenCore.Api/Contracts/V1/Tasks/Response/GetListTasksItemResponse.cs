namespace OpenCore.Api.Contracts.V1.Tasks.Response;

internal sealed record GetListTasksResponse
(
    Guid Id,
    string Title,
    string Status,
    DateTimeOffset CreatedAt
);
