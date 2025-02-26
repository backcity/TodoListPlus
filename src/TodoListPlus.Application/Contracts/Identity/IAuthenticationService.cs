using TodoListPlus.Application.Models.Authentication;

namespace TodoListPlus.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationRequest> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}