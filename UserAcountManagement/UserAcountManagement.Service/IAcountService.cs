using DTO;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public interface IAcountService
{
    public Task<bool> PostAcount(AcountDTO newAcount);
    public Task<Acount> GetAcount(AcountInfoDTO newAcountInfo);
}
