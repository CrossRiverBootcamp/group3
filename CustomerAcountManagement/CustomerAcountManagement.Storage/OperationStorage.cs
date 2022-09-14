
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAcountManagement.Storage;

public class OperationStorage : IOperationStorage
{
    private readonly IDbContextFactory<BankDBContext> _dbContextFactory;
    public OperationStorage(IDbContextFactory<BankDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public async Task<List<OperationModel>> GetOperationsHistory(int acountId, int pageNumber, int numberOfRecords)
    {
        var dbContext = _dbContextFactory.CreateDbContext();
        var position = pageNumber * numberOfRecords;
        var nextPage = await dbContext.Operations
            .Where(operation => operation.AcountId == acountId)
            .Join(dbContext.Operations, operation1 => operation1.TransactionId, operation2 => operation2.TransactionId,
                   (operation1, operation2) =>
                   new OperationModel()
                   {
                       Debit = operation1.Debit,
                       ThirdParty = operation2.AcountId,
                       Amount = operation1.TransactionAmount,
                       Balance = operation1.Balance,
                       Date = operation1.OperationTime
                   })
            .Where(operation => operation.ThirdParty != acountId)
            .OrderBy(b => b.Date)
            .Skip(position)
            .Take(numberOfRecords)
            .ToListAsync();
        return nextPage;
    }
    public async Task<int> GetOperationsNumber(int acountId)
    {
        var dbContext=_dbContextFactory.CreateDbContext();
        return (await dbContext.Operations
            .Where(operation => operation.AcountId == acountId)
            .Join(dbContext.Operations, operation1 => operation1.TransactionId, operation2 => operation2.TransactionId,
                   (operation1, operation2) =>
                   new OperationModel()
                   {
                       Debit = operation1.Debit,
                       ThirdParty = operation2.AcountId,
                       Amount = operation1.TransactionAmount,
                       Balance = operation1.Balance,
                       Date = operation1.OperationTime
                   })
            .Where(operation => operation.ThirdParty != acountId)
            .ToListAsync()).Count;
    }

}
