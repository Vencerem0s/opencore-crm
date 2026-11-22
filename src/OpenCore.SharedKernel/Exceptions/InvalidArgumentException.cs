namespace OpenCore.SharedKernel.Exceptions;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException()
        : base("Invalid argument") { }

    public InvalidArgumentException(string message)
        : base(message) { }
}
