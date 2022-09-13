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


    [HttpGet("AcountInfo/ {acountId}")]
    public async Task<ActionResult<AcountInfoDTO>> AcountInfo(int acountId)
    {
        try
        {
            return Ok(await _AcountService.GetAcount(acountId));

        }
        catch (Exception ex)
        {
            if (ex.Message == "Acount does not exist")
                return BadRequest("incorrect infomation");
            throw ex;
        }
    }
    [HttpGet("Customer/{acountId}")]
    public async Task<ActionResult<ThirdPartyDetails>> GetCustomerByAcountId(int acountId)
    {
        try
        {
            if (acountId == 0)
                return BadRequest();
            return Ok(await _AcountService.GetCustomerByAcountId(acountId));
        }
        catch(Exception ex)
        {
            throw ex;
        }


    }

}

