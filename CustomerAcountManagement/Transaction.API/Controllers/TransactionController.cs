using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transaction.DTO;
using Transaction.Service;

namespace Transaction.API.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;
    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<ActionResult> PostTransaction(TransactionDTO transactionDTO)
    {
        await _transactionService.PostTransaction(transactionDTO);
        return Accepted();
    }
}
