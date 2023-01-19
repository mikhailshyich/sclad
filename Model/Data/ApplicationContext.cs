using Microsoft.EntityFrameworkCore;
using Sclad.Model;

namespace Sclad.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ScladDB;Trusted_Connection=True;");
        }
    }
}
