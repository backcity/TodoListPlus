namespace TodoListPlus.Domain.Exceptions;

public class TodoListPlusDomainException : Exception
{
    public TodoListPlusDomainException()
    {
    }

    public TodoListPlusDomainException(string message) : base(message)
    {
    }

    public TodoListPlusDomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
