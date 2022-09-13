using CustomerAcountManagement.Storage;
using Microsoft.Extensions.Hosting;
using NSB.Messages.Commands;
using NSB.Messages.Events;
using NServiceBus;

namespace Acount.NSB
{
    public class IHandleTrnsferMoney : IHandleMessages<TransferMoney>
    {
        private readonly AcountStorage _AcountStorage;
        private readonly IHost _host;
        public IHandleTrnsferMoney(AcountStorage AcountStorage, IHost host)
        {
            _AcountStorage = AcountStorage;
            _host = host;
        }
        public async Task Handle(TransferMoney message, IMessageHandlerContext context)
        {
            try
            {
                int senderAcountId = await _AcountStorage.ValidateId(message.FromAcountId);
                if (senderAcountId == 0)
                    throw new Exception("Sender acount does not exist");
                int receiverAcountId = await _AcountStorage.ValidateId(message.ToAcountId);
                if (receiverAcountId == 0)
                    throw new Exception("Receiver acount does not exist");
                bool senderBalance = await _AcountStorage.ValidateSenderBalance(message.Amount, message.FromAcountId);
                if (senderBalance == false)
                    throw new Exception("You don't have enough money in your acount");
                bool UpdateBalance = await _AcountStorage.UpdateBalance(message.ToAcountId, message.FromAcountId, message.Amount);
                if (UpdateBalance == false)
                    throw new Exception("The acounts were not updated with the new balance");
                var transferrd = new Transferred
                {
                    Id = Guid.NewGuid(),
                    Result = true,
                    FailureReason = null
                };
                await context.Publish(transferrd);
            }
            catch (Exception ex)
            {
                var transferrd = new Transferred
                {
                    Id = Guid.NewGuid(),
                    Result = false,
                    FailureReason = null
                };
                if (ex.Message == "Sender acount does not exist")
                {
                    transferrd.FailureReason = "Sender acount does not exist";
                    await context.Publish(transferrd);
                }
                if (ex.Message == "Receiver acount does not exist")
                {
                    transferrd.FailureReason = "Receiver acount does not exist";
                    await context.Publish(transferrd);
                }
                if (ex.Message == "You don't have enough money in your acount")
                {
                    transferrd.FailureReason = "You don't have enough money in your acount";
                    await context.Publish(transferrd);
                }
                if (ex.Message == "The acounts were not updated with the new balance")
                {
                    transferrd.FailureReason = "The acounts were not updated with the new balance";
                    await context.Publish(transferrd);
                }

            }
            //Operation operation = _mapper.Map<Operation>(operationDTO);
            //operation.OperationTime = DateTime.Now;
            //await _operationStorage.PostOperation(operation);





        }
    }
}
