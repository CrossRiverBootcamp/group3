using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<RegisterDTO, Customer>().ReverseMap();
        CreateMap<Customer, AcountInfoDTO>().ReverseMap();
        CreateMap<Storage.Entities.Acount,AcountInfoDTO>().IncludeMembers(acount=>acount.Customer).ReverseMap();

    }

}
