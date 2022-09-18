using NServiceBus;
using System.ComponentModel.DataAnnotations;

namespace NSB.Messages.Commands;

public class UpdateTransactionStatus
{
    [Required]
    public Guid TransactionId { get; set; }
    [Required]
    public Guid Id { get; set; }
    public bool Result { get; set; }
    public string? FailureReason { get; set; }

}
