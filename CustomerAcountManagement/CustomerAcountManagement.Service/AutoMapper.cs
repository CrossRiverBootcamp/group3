using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;
using NSB.Messages.Commands;

namespace CustomerAcountManagement.Service;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<RegisterDTO, Customer>().ReverseMap();
        CreateMap<Customer, AcountInfoDTO>().ReverseMap();
        CreateMap<CustomerModel, ThirdPartyDetails>().ReverseMap();
        CreateMap<Storage.Entities.Acount,AcountInfoDTO>().IncludeMembers(acount=>acount.Customer).ReverseMap();
        CreateMap<OperationModel, OperationDTO>().ReverseMap();
        //CreateMap<TransferMoney, CreateOperationsDTO>().ReverseMap();
    }

}
