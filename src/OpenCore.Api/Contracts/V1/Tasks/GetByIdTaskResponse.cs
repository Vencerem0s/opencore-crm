namespace OpenCore.Api.Contracts.V1.Tasks;

public sealed record GetByIdTaskResponse
(
    Guid Id,
    string Title,
    DateTimeOffset CreatedAt
);
