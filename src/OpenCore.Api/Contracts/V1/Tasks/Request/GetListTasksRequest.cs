namespace OpenCore.Api.Contracts.V1.Tasks.Request;

public sealed record GetListTasksRequest(int Limit = 30, int Offset = 0);
