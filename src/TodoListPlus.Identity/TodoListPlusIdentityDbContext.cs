using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoListPlus.Identity
{
    public class TodoListPlusIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public TodoListPlusIdentityDbContext(DbContextOptions<TodoListPlusIdentityDbContext> options) : base(options)
        {
        }

        protected TodoListPlusIdentityDbContext()
        {
        }
    }
}
