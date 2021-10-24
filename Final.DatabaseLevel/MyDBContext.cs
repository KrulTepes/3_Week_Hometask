using Microsoft.EntityFrameworkCore;

namespace Final.DatabaseLevel
{
    public class MyDBContext : DbContext
    {
        // Host=localhost;Port=5432;Database=MyDatabase;Username=postgres;Password=admin
        public DbSet<DataModel> Cars { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyDatabase;Username=postgres;Password=admin");
        }
    }
}
