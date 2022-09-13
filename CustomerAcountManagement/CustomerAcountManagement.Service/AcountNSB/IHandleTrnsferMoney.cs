﻿using CustomerAcountManagement.Storage;
using NSB.Messages.Commands;
using NSB.Messages.Events;
using NServiceBus;

namespace Acount.NSB
{
    public class IHandleTrnsferMoney : IHandleMessages<TransferMoney>
    {
        private readonly IAcountStorage _AcountStorage;

        public IHandleTrnsferMoney(IAcountStorage AcountStorage)
        {
            _AcountStorage = AcountStorage;
            
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
                Transferred transferred = new Transferred
                {

                    SagaId = message.SagaId,
                    Id = Guid.NewGuid(),
                    Result = true,
                    FailureReason = null
                };
                await context.Publish(transferred);
            }
            catch (Exception ex)
            {
                Transferred transferred = new Transferred
                {
                    SagaId =message.SagaId,
                    Id = Guid.NewGuid(),
                    Result = false,
                    FailureReason = null
                };
                if (ex.Message == "Sender acount does not exist")
                {
                    transferred.FailureReason = "Sender acount does not exist";
                    await context.Publish(transferred);
                }
                if (ex.Message == "Receiver acount does not exist")
                {
                    transferred.FailureReason = "Receiver acount does not exist";
                    await context.Publish(transferred);
                }
                if (ex.Message == "You don't have enough money in your acount")
                {
                    transferred.FailureReason = "You don't have enough money in your acount";
                    await context.Publish(transferred);
                }
                if (ex.Message == "The acounts were not updated with the new balance")
                {
                    transferred.FailureReason = "The acounts were not updated with the new balance";
                    await context.Publish(transferred);
                }

            }
            //Operation operation = _mapper.Map<Operation>(operationDTO);
            //operation.OperationTime = DateTime.Now;
            //await _operationStorage.PostOperation(operation);





        }
    }
}