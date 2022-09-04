
using Microsoft.EntityFrameworkCore;

namespace UserAcountManagement.Storage.Entities;

public class BankDBContext:DbContext
{
    public BankDBContext(DbContextOptions options):base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;database=BankDB;Trusted_Connection=True;");
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Acount> Acounts { get; set; }
}
