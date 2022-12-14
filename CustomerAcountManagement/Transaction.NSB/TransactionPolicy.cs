using AutoMapper;
using NSB.Messages.Commands;
using NSB.Messages.Events;
using NServiceBus;

namespace Transaction.NSB;
public class TransactionPolicy : Saga<TransactionPolicyData>
, IAmStartedByMessages<Payload>,
IAmStartedByMessages<Transferred>
{

    private IMapper _mapper;
    public TransactionPolicy(IMapper mapper)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapper>();
        });
        _mapper = config.CreateMapper();

    }

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TransactionPolicyData> mapper)
    {
        mapper.MapSaga(sagaData => sagaData.Id)
               .ToMessage<Payload>(message => message.TransactionId)
               .ToMessage<Transferred>(message => message.TransactionId
              );
    }
    public async Task Handle(Payload message, IMessageHandlerContext context)
    {
        TransferMoney transferMoney = _mapper.Map<TransferMoney>(message);
        transferMoney.Id = Guid.NewGuid();
        await context.Send(transferMoney);
    }

    public async Task Handle(Transferred message, IMessageHandlerContext context)
    {
        UpdateTransactionStatus updateTransactionStatus = _mapper.Map<UpdateTransactionStatus>(message);
        updateTransactionStatus.Id = Guid.NewGuid();
        await context.Send(updateTransactionStatus);
        MarkAsComplete();
    }
}
