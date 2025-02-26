namespace TodoListPlus.Application.Models.Authentication;

public record class AuthenticationResponse(
    string Id,
    string UserName,
    string Email,
    string Token);
