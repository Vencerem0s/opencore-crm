using OpenCore.Domain.Tasks.Enum;

namespace OpenCore.Api.Contracts.V1.Tasks;

internal static class TaskItemStatusExtensions
{
    public static string Label(this TaskItemStatus status)
    {
        return status switch
        {
            TaskItemStatus.Created => "Created",
            TaskItemStatus.Deleted => "Deleted",
            TaskItemStatus.Ended => "Ended",
            TaskItemStatus.InWork => "In Work",
            _ => throw new ArgumentOutOfRangeException(
                    nameof(status),
                    status,
                    "no string representation for the status"
                )
        };
    }
}
