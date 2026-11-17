namespace OpenCore.Application.Tasks.DTO;

public sealed record TaskDetailsDTO
(
    Guid Id,
    string Title,
    DateTimeOffset CreatedAt
);
