
using Microsoft.EntityFrameworkCore;

namespace TaskKevin.ModelsLibrary.Data.Model
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V89NH6D\SQLEXPRESS;Initial Catalog=task-db;Integrated Security=True");
        }
        public DbSet<User> userTable{ get; set; }
        public DbSet<Task> taskTable { get; set; }
        public DbSet<Projects> projectsTable { get; set; }
        public DbSet<Roles> rolesTable { get; set; }
    }
}