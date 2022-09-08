using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.DTO;

namespace Transaction.Service;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<TransactionDTO, Ttransaction.Storage.Entities.Transaction>().ReverseMap();
    }
}
