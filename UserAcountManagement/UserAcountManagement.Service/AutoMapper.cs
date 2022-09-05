﻿using AutoMapper;
using DTO;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<RegisterDTO, Customer>().ReverseMap();

    }

}
