using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListPlus.Application.Contracts
{
    public interface ILoggedInUserService
    {
        string GetUserIdentity();
    }
}
