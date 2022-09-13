
using NServiceBus;

namespace Transaction.NSB;
public class TransactionPolicyData : ContainSagaData
{
    public Guid Id { get; set; }
}
