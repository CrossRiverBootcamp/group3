
using NServiceBus;

namespace Transaction.NSB;
public class TransactionPolicyData : ContainSagaData
{
    public string Id { get; set; }
}
