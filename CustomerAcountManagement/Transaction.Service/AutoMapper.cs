using AutoMapper;
using Transaction.DTO;

namespace Transaction.Service;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<TransactionDTO, Ttransaction.Storage.Entities.Transaction>().ReverseMap();
    }
}
