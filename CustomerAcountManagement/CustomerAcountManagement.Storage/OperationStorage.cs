
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
    public async Task PostOperation(Operation operation)
    {
        if (operation == null)
            throw new ArgumentNullException(nameof(operation));
        operation.AcountId = 1;
        operation.TransactionId = Guid.NewGuid();
        Operation operation1 = new()
        {
            Id = Guid.NewGuid(),
            OperationTime = DateTime.Now,
            AcountId = 3,
            TransactionId = operation.TransactionId,
            Debit = !operation.Debit,
            TransactionAmount = operation.TransactionAmount,
            Balance = operation.Balance

        };
        var dbContext = _dbContextFactory.CreateDbContext();
        await dbContext.Operations.AddAsync(operation);
        await dbContext.Operations.AddAsync(operation1);
        await dbContext.SaveChangesAsync();

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
