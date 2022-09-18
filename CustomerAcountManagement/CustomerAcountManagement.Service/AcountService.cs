using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;

namespace CustomerAcountManagement.Service;

public class AcountService : IAcountService
{
    private readonly IAcountStorage _acountStorage;
    private readonly IMapper _mapper;
    public AcountService(IAcountStorage acountStorag, IMapper mapper)
    {
        _acountStorage = acountStorag;
        _mapper = mapper;
    }

    public async Task<AcountInfoDTO> GetAcount(int acountId)
    {
        try
        {
            Storage.Entities.Acount acount = await _acountStorage.GetAcountInfo(acountId);
            if (acount != null)
                return _mapper.Map<AcountInfoDTO>(acount);
            throw new Exception("Acount does not exist");
            

        }
        catch(Exception ex)
        {
            throw ex;

        }
    }
    public async Task<ThirdPartyDetails> GetCustomerByAcountId(int acountId)
    {
        if (acountId == 0)
            throw new ArgumentNullException();
        CustomerModel customer=await _acountStorage.GetCustomerByAcountId(acountId);
        if (customer == null)
            throw new Exception("Customer does not exist");
        return _mapper.Map<ThirdPartyDetails>(customer);
    }
      
}
