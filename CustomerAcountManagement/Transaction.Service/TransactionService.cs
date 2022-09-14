using AutoMapper;
using NSB.Messages.Events;
using NServiceBus;
using Transaction.DTO;
using Ttransaction.Storage;

namespace Transaction.Service;

public class TransactionService : ITransactionService
{
    private readonly ITransactionStorage _transactionStorage;
    private readonly IMapper _mapper;
    private readonly IMessageSession _messageSession;
    public TransactionService(ITransactionStorage transactionStorage, IMapper mapper, IMessageSession messageSession)
    {
        _transactionStorage = transactionStorage;
        _mapper = mapper;
        _messageSession = messageSession;
    }
    public async Task PostTransaction(TransactionDTO transactionDTO)
    {
        try
        {
            Ttransaction.Storage.Entities.Transaction transaction = _mapper.Map<Ttransaction.Storage.Entities.Transaction>(transactionDTO);
            transaction.Date=DateTime.Now;
            await _transactionStorage.CreateTransaction(transaction);
            Payload payload = new() {
                TransactionId= transaction.Id,
                Id = Guid.NewGuid(),
                FromAcountId = transactionDTO.FromAccountID,
                ToAcountId = transactionDTO.ToAccountID,
                Amount=transactionDTO.Amount
            };
            
            await _messageSession.Publish(payload);

        }
        catch
        {

        }
    }
    public async Task UpdateTransactionStatus(Guid transactionId, string? failureReason)
    {
        try
        {
            _transactionStorage.UpdateTransactionStatus(transactionId, failureReason);

        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

}
