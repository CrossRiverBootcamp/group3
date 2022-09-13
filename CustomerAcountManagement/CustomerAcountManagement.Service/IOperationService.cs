
using DTO;

namespace CustomerAcountManagement.Service;

public interface IOperationService
{
    public Task<List<OperationDTO>> GetOperationsHistory(int acountId, int pageNumber, int numberOfRecords);
    public Task<int> GetOperationsNumber(int acountId);

    public Task PostOperation(OperationDTO operationDTO);
}
