using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListPlus.Identity.Models;

namespace TodoListPlus.Identity
{
    public class TodoListPlusIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TodoListPlusIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TodoListPlusIdentityDbContext()
        {
        }
    }
}
