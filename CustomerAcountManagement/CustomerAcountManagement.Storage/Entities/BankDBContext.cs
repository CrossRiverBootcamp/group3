
using Microsoft.EntityFrameworkCore;

namespace CustomerAcountManagement.Storage.Entities;

public class BankDBContext : DbContext
{
    public BankDBContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Acount> Acounts { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<EmailVerification> EmailVerifications { get; set; }
}
