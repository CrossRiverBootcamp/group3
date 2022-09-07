
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Storage;

public interface IAcountStorage
{
    public Task CreateAcount(Acount acount);
    public Task<Acount> GetAcountInfo(int acountId);
    public Task<int> GetAcountIdByCustomerId(int customerId);
    public Task<bool> ValidateSenderBalance(int balance, int idSender);
    public Task<bool> UpdateBalance(int receiverId, int senderId, int amount);
    public Task<int> ValidateId(int id);

}
