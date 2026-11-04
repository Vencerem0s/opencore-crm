using OpenCore.SharedKernel.Exceptions.Domain;

namespace OpenCore.Domain.Tasks.ValueObject;

public sealed record TaskTitle
{
    public const int MaxLength = 200;

    public string Value { get; } = string.Empty;

    private TaskTitle(string title)
    {
        Value = title;
    }

    public static TaskTitle Create(string title)
    {
        title = title.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new VOException("Task Title is empty");
        }

        if (title.Length > MaxLength)
        {
            throw new VOException($"Task Title is longer then {MaxLength}");
        }

        return new TaskTitle(title);
    }
}
