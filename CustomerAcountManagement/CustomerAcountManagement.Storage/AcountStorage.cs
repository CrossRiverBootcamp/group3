
using Microsoft.EntityFrameworkCore;
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;

namespace CustomerAcountManagement.Storage;

public class AcountStorage : IAcountStorage
{
    private readonly IDbContextFactory<BankDBContext> _dbContextFactory;
    public AcountStorage(IDbContextFactory<BankDBContext> dbContestFactory)
    {
        _dbContextFactory = dbContestFactory;
    }

    public async Task CreateAcount(Acount acount)
    {
        if (acount == null)
        {
            throw new ArgumentNullException(nameof(acount));
        }
        var context = _dbContextFactory.CreateDbContext();
        context.Acounts.Add(acount);
        await context.SaveChangesAsync();

    }

    public async Task<Acount> GetAcountInfo(int acountId)
    {
        if (acountId == 0)
        {
            throw new ArgumentNullException(nameof(acountId));
        }
        var context = _dbContextFactory.CreateDbContext();
        return await context.Acounts.Include(acount => acount.Customer).FirstOrDefaultAsync(acount => acount.Id == acountId);
    }
    public async Task<CustomerModel> GetCustomerByAcountId(int acountId)
    {
        if (acountId == null)
            throw new ArgumentNullException();
        var dbContext=_dbContextFactory.CreateDbContext();
        return await dbContext.Acounts
            .Where(acount => acount.Id == acountId)
            .Include(acount => acount.Customer)
            .Select(acount => new CustomerModel
            {
                FirstName = acount.Customer.FirstName,
                LastName = acount.Customer.LastName,
                Email = acount.Customer.Email
            }).FirstOrDefaultAsync();
    }
    public async Task<int> GetAcountIdByCustomerId(int customerId)
    {
        if (customerId == 0)
            throw new ArgumentNullException(nameof(customerId));
        var context = _dbContextFactory.CreateDbContext();
        return (await context.Acounts.FirstOrDefaultAsync(acount => acount.CustomerId == customerId)).Id;
    }
    public async Task<bool> ValidateSenderBalance(int balance, int idSender)
    {
        if (balance == 0 || idSender == 0)
            throw new ArgumentNullException();
        var context = _dbContextFactory.CreateDbContext();
        int senderBalance = (await context.Acounts.FirstOrDefaultAsync(acount => acount.CustomerId == idSender)).Balance;
        if (senderBalance >= balance)
        {
            return true;
        }
        return false;


    }
    public async Task<bool> UpdateBalanceAndCreateOperations(int receiverId, int senderId, int amount, Guid transactionId)
    {
        if (receiverId == 0 || senderId == 0 || amount == 0)
            throw new ArgumentNullException();
        var context = _dbContextFactory.CreateDbContext();
        try
        {
            Acount senderAcount = await context.Acounts.FirstOrDefaultAsync(acount => acount.Id == senderId);
            senderAcount.Balance -= amount;
            Acount receiverAcount = await context.Acounts.FirstOrDefaultAsync(acount => acount.Id == receiverId);
            receiverAcount.Balance += amount;
            DateTime operationTime = DateTime.Now;
            Operation fromOperation = new()
            {
                AcountId = senderAcount.Id,
                TransactionId = transactionId,
                Debit = false,
                TransactionAmount = amount,
                Balance = senderAcount.Balance,
                OperationTime = operationTime

            };
            Operation toOperation = new()
            {
                AcountId = receiverId,
                TransactionId = transactionId,
                Debit = true,
                TransactionAmount = amount,
                Balance = receiverAcount.Balance,
                OperationTime = operationTime

            };
            context.Operations.Add(toOperation);
            context.Operations.Add(fromOperation);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<int > ValidateId(int id)
    {
        if (id <= 0)
            throw new ArgumentNullException();
        var dbContext = _dbContextFactory.CreateDbContext();
        Acount Acount= await dbContext.Acounts.FirstOrDefaultAsync(acout => acout.Id == id);
        if (Acount == null)
            return 0;
        return Acount.Id;
    }

}
