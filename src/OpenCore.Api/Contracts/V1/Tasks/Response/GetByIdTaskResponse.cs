namespace OpenCore.Api.Contracts.V1.Tasks.Response;

public sealed record GetByIdTaskResponse
(
    Guid Id,
    string Title,
    string Status,
    DateTimeOffset CreatedAt
);
