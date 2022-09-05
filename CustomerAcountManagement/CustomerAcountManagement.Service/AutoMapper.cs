using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<RegisterDTO, Customer>().ReverseMap();

    }

}
