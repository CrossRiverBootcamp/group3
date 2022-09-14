using NServiceBus;
using System.ComponentModel.DataAnnotations;

namespace NSB.Messages.Commands
{
    public class TransferMoney : ICommand
    {
        [Required]
        public Guid TransactionId { get; set; }
        public Guid Id { get; set; }
        public int FromAcountId { get; set; }
        public int ToAcountId { get; set; }
        public int Amount { get; set; }
    }
}
