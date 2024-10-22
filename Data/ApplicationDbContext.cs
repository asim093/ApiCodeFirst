using CodeFirstApi.Model;

using Microsoft.EntityFrameworkCore;

namespace CodeFirstApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options)
            : base(options) { 
        
        }
    public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventType { get; set; } 
    }
}
