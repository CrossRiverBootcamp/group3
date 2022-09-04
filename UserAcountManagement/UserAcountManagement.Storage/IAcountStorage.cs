
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public interface IAcountStorage
{
    public Task CreateAcount(Acount acount);
    public Task<Acount> GetAcountInfo(int acountId);
    public Task<int> GetAcountIdByCustomerId(int customerId);

}
