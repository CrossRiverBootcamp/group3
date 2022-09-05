using DTO;
using Microsoft.AspNetCore.Mvc;
using CustomerAcountManagement.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAcountManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcountController : ControllerBase
{
    private readonly IAcountService _AcountService;
    public AcountController(IAcountService AcountService)
    {
        _AcountService = AcountService;
    }


    [HttpGet("AcountInfo")]
    public async Task<ActionResult<int>> AcountInfo([FromBody] AcountInfoDTO acountInfoDTO)
    {
        try
        {
            return Ok(await _AcountService.GetAcount(acountInfoDTO));

        }
        catch (Exception ex)
        {
            if (ex.Message == "Acount does not exist")
                return BadRequest("incorrect infomation");
            throw ex;
        }
    }

}

