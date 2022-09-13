using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;

namespace CustomerAcountManagement.Service;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<RegisterDTO, Customer>().ReverseMap();
        CreateMap<Customer, AcountInfoDTO>().ReverseMap();
        CreateMap<CustomerModel, ThirdPartyDetails>().ReverseMap();
        CreateMap<Acount,AcountInfoDTO>().IncludeMembers(acount=>acount.Customer).ReverseMap();
        CreateMap<OperationModel, OperationDTO>().ReverseMap();
        CreateMap<Operation, OperationDTO>().ReverseMap();
    }

}
