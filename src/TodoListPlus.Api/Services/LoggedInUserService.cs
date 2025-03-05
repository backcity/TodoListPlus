using TodoListPlus.Application.Contracts;

namespace TodoListPlus.Api.Services
{
    public class LoggedInUserService(IHttpContextAccessor context) : ILoggedInUserService
    {
        public string GetUserIdentity()
        {
          return  context.HttpContext?.User.FindFirst("sub")?.Value;
        }
    }
}
