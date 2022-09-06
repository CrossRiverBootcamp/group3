using DTO;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;

public interface IAcountService
{
    public Task<bool> PostAcount(AcountDTO newAcount);
    public Task<AcountInfoDTO> GetAcount(int acountId);
}
