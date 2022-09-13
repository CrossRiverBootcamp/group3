using CustomerAcountManagement.Service;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAcountManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OperationController : Controller
{
    private readonly IOperationService _operationService;
    public OperationController(IOperationService operationService)
    {
        _operationService = operationService;
    }
    [HttpGet("{acountId}/{pageNumber}/{numberOfRecords}")]
    public async Task<ActionResult<List<OperationDTO>>> GetOperationsHistory(int acountId, int pageNumber, int numberOfRecords)
    {
        if (acountId == 0)
            return BadRequest();
        return await _operationService.GetOperationsHistory(acountId,pageNumber,numberOfRecords);
    }
    [HttpGet("{acountId}")]
    public async Task<ActionResult<int>> GetOperationsNumber(int acountId)
    {
        if (acountId == 0)
            return BadRequest();
        return await _operationService.GetOperationsNumber(acountId);
    }
    [HttpPost]

    public async Task PostOperation([FromBody] OperationDTO operation)
    {
       await _operationService.PostOperation(operation);
    }
}
