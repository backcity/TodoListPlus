using TodoListPlus.Application.Contracts.Identity;

namespace TodoListPlus.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<AuthenticationRequest> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
