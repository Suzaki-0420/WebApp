namespace WebApp_Sample_Show.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message)
    : base() { }
    public DomainException(string message, Exception innerException)
    : base(message, innerException) { }
}