using System.ComponentModel.DataAnnotations;

namespace NSB.Messages.Events;

public class Payload 
{
    [Required]
    public Guid TransactionId { get; set; }
    [Required]
    public Guid Id { get; set; }
    [Required]
    public int FromAcountId { get; set; }
    [Required]
    public int ToAcountId { get; set; }
    [Required]
    public int Amount { get; set; }

}
