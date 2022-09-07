using Ttransaction.Storage.Entities;

namespace Ttransaction.Storage
{
    public interface ITransactionStorage
    {
        public Task<Transaction> CreateTransaction(Transaction transaction);
        




    }
}
