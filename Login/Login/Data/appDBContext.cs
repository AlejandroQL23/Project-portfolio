using Microsoft.EntityFrameworkCore;
using Login.Models;

namespace Login.Data
{
    public class appDBContext:DbContext
    {
        public appDBContext(DbContextOptions<appDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(tb =>
            {
            tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.FullName)
                .HasMaxLength(50);

                tb.Property(col => col.Email)
               .HasMaxLength(50);

                tb.Property(col => col.Password)
               .HasMaxLength(50);
            });

            modelBuilder.Entity<User>().ToTable("user");
        }



    }
}
