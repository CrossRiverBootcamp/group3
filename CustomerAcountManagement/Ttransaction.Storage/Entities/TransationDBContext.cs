using Microsoft.EntityFrameworkCore;
namespace Ttransaction.Storage.Entities
{
    public class TransationDBContext:DbContext
    {
        public TransationDBContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
