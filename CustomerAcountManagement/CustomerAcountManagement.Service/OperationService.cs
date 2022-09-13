using AutoMapper;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using CustomerAcountManagement.Storage.models;
using DTO;

namespace CustomerAcountManagement.Service;

public class OperationService : IOperationService
{
    private readonly IOperationStorage _operationStorage;
    private readonly IMapper _mapper;
    public OperationService(IOperationStorage operationStorage, IMapper mapper)
    {
        _operationStorage = operationStorage;
        _mapper = mapper;
    }
    public async Task<List<OperationDTO>> GetOperationsHistory(int acountId, int pageNumber, int numberOfRecords)
    {
        List<OperationModel> operations = await _operationStorage.GetOperationsHistory(acountId, pageNumber, numberOfRecords);
        if (operations == null)
            return null;
        else
        {
            List<OperationDTO> operationsDTO = operations.ConvertAll(operation => _mapper.Map<OperationDTO>(operation));
            return operationsDTO;
        }
    }
    public async Task<int> GetOperationsNumber(int acountId)
    {
        int operationsNumber = await _operationStorage.GetOperationsNumber(acountId);
        return operationsNumber;
    }
    public async Task PostOperation(OperationDTO operation)
    {
        await _operationStorage.PostOperation(_mapper.Map<Operation>(operation));
    }
}
