using NServiceBus;
using System.ComponentModel.DataAnnotations;

namespace NSB.Messages.Events;

public class Payload : IEvent
{
    [Required]
    public string Id { get; set; }
    [Required]
    public int FromAcountId { get; set; }
    [Required]
    public int ToAcountId { get; set; }
    [Required]
    public int Amount { get; set; }

}
