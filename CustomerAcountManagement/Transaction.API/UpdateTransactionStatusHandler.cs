using NSB.Messages.Commands;
using NServiceBus;
using Transaction.Service;

namespace Transaction.API;

public class UpdateTransactionStatusHandler : IHandleMessages<UpdateTransactionStatus>
{
    ITransactionService _transactionService;
    public UpdateTransactionStatusHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    public async Task Handle(UpdateTransactionStatus message, IMessageHandlerContext context)
    {
        if (message.Result)
        {
            await _transactionService.UpdateTransactionStatus(message.Id, null);
        }
        else
        {
            await _transactionService.UpdateTransactionStatus(message.Id, message.FailureReason);

        }
    }
}
