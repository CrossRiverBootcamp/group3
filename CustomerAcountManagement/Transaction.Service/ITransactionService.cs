using Transaction.DTO;

namespace Transaction.Service;

public interface ITransactionService
{
    Task PostTransaction(TransactionDTO transactionDTO);
    Task UpdateTransactionStatus(Guid transactionId, string? failureReason);
}
