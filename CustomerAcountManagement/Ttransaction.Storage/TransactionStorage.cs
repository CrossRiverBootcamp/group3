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


        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException();
            var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
            return transaction;
        }
    }
}
