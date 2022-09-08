using NServiceBus;

namespace NSB.Messages.Commands
{
    public class TransferMoney : ICommand
    {
        public string Id { get; set; }
        public int FromAcountId { get; set; }
        public int ToAcountId { get; set; }
        public int Amount { get; set; }
    }
}
