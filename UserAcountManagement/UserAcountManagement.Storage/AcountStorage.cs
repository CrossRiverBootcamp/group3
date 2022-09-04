
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public class AcountStorage : IAcountStorage
{
    public Task CreateAcount(Acount acount)
    {
        throw new NotImplementedException();
    }

    public Task<Acount> GetAcountInfo(string acountId)
    {
        throw new NotImplementedException();
    }
}
