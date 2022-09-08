using Ttransaction.Storage.Entities;

namespace Ttransaction.Storage
{
    public interface ITransactionStorage
    {
        public Task CreateTransaction(Transaction transaction);
        public Task UpdateTransactionStatus(string transactionId, string? failureReason);

    }
}
