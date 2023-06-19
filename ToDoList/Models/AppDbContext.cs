using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Table> Tables { get; set; }


    }
}
