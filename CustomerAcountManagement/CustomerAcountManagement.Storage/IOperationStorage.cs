

using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;

namespace CustomerAcountManagement.Storage;

public interface IOperationStorage
{
    public Task<List<OperationModel>> GetOperationsHistory(int acountId, int pageNumber, int numberOfRecords);
    public Task<int> GetOperationsNumber(int acountId);

}
