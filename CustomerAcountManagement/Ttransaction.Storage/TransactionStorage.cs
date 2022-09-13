using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ttransaction.Storage.Entities;

namespace Ttransaction.Storage
{
    public class TransactionStorage : ITransactionStorage
    {
        IDbContextFactory<TransationDBContext> _dbContextFactory;
        public TransactionStorage(IDbContextFactory<TransationDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException();
            var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateTransactionStatus(Guid transactionId, string? failureReason)
        {
            if (transactionId == null)
                throw new ArgumentNullException();
            var dbContext = _dbContextFactory.CreateDbContext();
            Transaction transaction = await dbContext.Transactions.FirstOrDefaultAsync(transaction => transaction.Id.Equals(transactionId));
            if (transaction == null)
                throw new Exception("Transaction not exist");
            if (failureReason != null)
            {
                transaction.status = Status.Failure;
                transaction.FailureReason = failureReason;
            }
            else
                transaction.status=Status.Success;
            dbContext.SaveChangesAsync();

        }
    }
}
