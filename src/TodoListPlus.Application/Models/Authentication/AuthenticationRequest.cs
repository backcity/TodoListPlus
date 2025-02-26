using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListPlus.Application.Models.Authentication;

public record class AuthenticationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
