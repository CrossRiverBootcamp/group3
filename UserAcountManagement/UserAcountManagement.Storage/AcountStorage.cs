
using Microsoft.EntityFrameworkCore;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public class AcountStorage : IAcountStorage
{
    private readonly IDbContextFactory<BankDBContext> _dbContextFactory;
    public AcountStorage(IDbContextFactory<BankDBContext> dbContestFactory)
    {
        _dbContextFactory = dbContestFactory;
    }
    
    public async Task CreateAcount(Acount acount)
    {
       if(acount == null)
        {
            throw new ArgumentNullException(nameof(acount));
        }
        var context=_dbContextFactory.CreateDbContext();
        context.Acounts.Add(acount);
        await context.SaveChangesAsync();

    }

      public async Task<Acount> GetAcountInfo(int acountId)
    {
        if (acountId == 0)
        {
            throw new ArgumentNullException(nameof(acountId));
        }
        var context=_dbContextFactory.CreateDbContext();
        return await context.Acounts.Include(acount=>acount.Customer).FirstOrDefaultAsync(acount => acount.Id == acountId);
    }
    public async Task<int> GetAcountIdByCustomerId(int customerId)
    {
        if (customerId == 0)
            throw new ArgumentNullException(nameof(customerId));
        var context = _dbContextFactory.CreateDbContext();
        return (await context.Acounts.FirstOrDefaultAsync(acount => acount.CustomerId == customerId)).Id;
    }
}
