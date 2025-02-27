namespace TodoListPlus.Domain.Exceptions;

public class TodoListPlusException : Exception
{
    public TodoListPlusException()
    {
    }

    public TodoListPlusException(string message) : base(message)
    {
    }

    public TodoListPlusException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
