using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Web.Data
{
    public class EventContext : IdentityDbContext<IdentityUser>
    {
        public EventContext(DbContextOptions<EventContext> options) 
            : base(options)
        {
        }

        public DbSet<EventViewModel> Events { get; set; }       //Table 1
        public DbSet<CommentViewModel> Comments { get; set; }       //Table 2

    }
}