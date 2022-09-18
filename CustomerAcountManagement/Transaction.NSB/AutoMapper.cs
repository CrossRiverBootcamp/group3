using AutoMapper;
using NSB.Messages.Commands;
using NSB.Messages.Events;

namespace Transaction.NSB;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<Payload, TransferMoney>().ReverseMap();
        CreateMap<Transferred, UpdateTransactionStatus>().ReverseMap();
    }
}
