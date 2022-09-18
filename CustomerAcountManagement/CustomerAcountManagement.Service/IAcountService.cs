using DTO;

namespace CustomerAcountManagement.Service;

public interface IAcountService
{
    
    public Task<AcountInfoDTO> GetAcount(int acountId);
    public Task<ThirdPartyDetails> GetCustomerByAcountId(int acountId);
}
