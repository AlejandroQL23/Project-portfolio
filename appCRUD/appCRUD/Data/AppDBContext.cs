using Microsoft.EntityFrameworkCore;
using appCRUD.Models;

namespace appCRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {
            
        }

        public DbSet<employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<employee>(tb =>
            {
                tb.HasKey(col => col.Id);

                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.FullName).HasMaxLength(50);
                tb.Property(col => col.Mail).HasMaxLength(50);
            });

            modelBuilder.Entity<employee>().ToTable("Employee");
        }
    }
}
