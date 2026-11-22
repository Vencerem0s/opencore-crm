using OpenCore.Domain.Tasks.Enum;

namespace OpenCore.Application.Tasks.DTO;

public sealed record TaskListItemDTO
(
    Guid Id,
    string Title,
    TaskItemStatus Status,
    DateTimeOffset CreatedAt
 );
