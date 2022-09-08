using AutoMapper;
using NSB.Messages.Commands;
using NSB.Messages.Events;
using NServiceBus;
using Transaction.Service;

namespace Transaction.NSB;
public class TransactionPolicy : Saga<TransactionPolicyData>
, IAmStartedByMessages<Payload>,
IHandleMessages<Transferrd>
{

    private readonly IMapper _mapper;
    public TransactionPolicy(IMapper mapper)
    {
        _mapper = mapper;
    }
    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TransactionPolicyData> mapper)
    {
        mapper.MapSaga(sagaData => sagaData.Id)
               .ToMessage<Payload>(message => message.Id)
               .ToMessage<Transferred>(message => message.Id);
    }
    public async Task Handle(Payload message, IMessageHandlerContext context)
    {
        TransferMoney transferMoney = _mapper.Map<TransferMoney>(message);
        await context.Send(transferMoney);
    }

    public async Task Handle(Transferred message, IMessageHandlerContext context)
    {
        UpdateTransactionStatus updateTransactionStatus = _mapper.Map<UpdateTransactionStatus>(message);
        await context.Send(updateTransactionStatus);
        MarkAsComplete();
    }
}
