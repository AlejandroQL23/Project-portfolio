using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebAPIPerson.Contex
{
    public class AppBDContext : DbContext
    {
        public AppBDContext(DbContextOptions<AppBDContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

    }
}
