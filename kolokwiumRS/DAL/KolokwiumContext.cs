using Microsoft.EntityFrameworkCore;
using Model;


namespace DAL
{
    public class KolokwiumContext : DbContext
    {

  

        public DbSet<Student> Studenci { get; set; }
        public DbSet<Grupa> Groupy { get; set; }
        public DbSet<Historia> Historie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kolokwiumDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
