namespace OpenCore.Application.Tasks.Query;

public sealed record GetListTasksQuery
(
    int Limit,
    int Offset
 );
