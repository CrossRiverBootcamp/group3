using NServiceBus;

namespace NSB.Messages.Commands;

public class UpdateTransactionStatus:ICommand
{
    public string Id { get; set; }
    public bool Result { get; set; }
    public string? FailureReason { get; set; }

}
