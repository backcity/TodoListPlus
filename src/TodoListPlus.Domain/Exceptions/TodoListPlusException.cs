using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListPlus.Domain.Exceptions
{
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
}
