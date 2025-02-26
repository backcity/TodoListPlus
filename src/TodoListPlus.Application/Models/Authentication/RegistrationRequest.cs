using System.ComponentModel.DataAnnotations;

namespace TodoListPlus.Application.Models.Authentication;

public record class RegistrationRequest([Required] string FirstName,
    [Required] string LastName,
    [Required][EmailAddress] string Email,
    [Required][MinLength(6)] string UserName,
    [Required][MinLength(6)] string Password);