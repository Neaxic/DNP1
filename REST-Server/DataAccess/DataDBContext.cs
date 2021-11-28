using Microsoft.EntityFrameworkCore;
using Models;

namespace REST_Server.DataAccess
{
    public class DataDBContext : DbContext
    {
        public DbSet<Adult> adults { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Adult.db");
        }
    }
}