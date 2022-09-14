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
    //public async Task PostOperation(OperationDTO createOperations)
    //{
    //    DateTime operationTime = DateTime.Now;
    //    Operation fromOperation = new()
    //    {
    //        AcountId = createOperations.FromAcountId,
    //        TransactionId = createOperations.TransactionId,
    //        Debit = false,
    //        TransactionAmount = createOperations.Amount,
    //        Balance = 0,
    //        OperationTime = operationTime

    //    };
    //    Operation toOperation = new()
    //    {
    //        AcountId = createOperations.ToAcountId,
    //        TransactionId = createOperations.TransactionId,
    //        Debit = true,
    //        TransactionAmount = createOperations.Amount,
    //        Balance = 0,
    //        OperationTime = operationTime

    //    };
        //await _operationStorage.PostOperation(fromOperation);

        //await _operationStorage.PostOperation(toOperation);

    //}
}
