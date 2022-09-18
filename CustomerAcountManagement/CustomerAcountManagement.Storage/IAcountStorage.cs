using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;

namespace CustomerAcountManagement.Storage;

public interface IAcountStorage
{
    public Task CreateAcount(Acount acount);
    public Task<Acount> GetAcountInfo(int acountId);
    public Task<CustomerModel> GetCustomerByAcountId(int acountId);
    public Task<int> GetAcountIdByCustomerId(int customerId);
    public Task<bool> ValidateSenderBalance(int balance, int idSender);
    public Task<bool> UpdateBalanceAndCreateOperations(int receiverId, int senderId, int amount, Guid transactionId);
    public Task<int> ValidateId(int id);

}
