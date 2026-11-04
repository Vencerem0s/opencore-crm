namespace OpenCore.SharedKernel.Exceptions.Domain;

public class VOException : Exception
{
    public VOException()
        : base("Value Object exception") { }

    public VOException(string message)
        : base(message) { }
}
