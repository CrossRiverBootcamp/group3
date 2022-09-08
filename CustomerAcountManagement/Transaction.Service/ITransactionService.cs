using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.DTO;

namespace Transaction.Service;

public interface ITransactionService
{
    Task PostTransaction(TransactionDTO transactionDTO);
    Task UpdateTransactionStatus(string transactionId, string? failureReason);
}
