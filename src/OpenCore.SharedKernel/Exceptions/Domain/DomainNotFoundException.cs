namespace OpenCore.SharedKernel.Exceptions.Domain;

public class DomainNotFoundException : Exception
{
    public DomainNotFoundException()
        : base("Domain not found") { }

    public DomainNotFoundException(string message)
        : base(message) { }
}
