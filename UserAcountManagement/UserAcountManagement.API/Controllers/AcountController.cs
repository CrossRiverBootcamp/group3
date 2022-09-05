using DTO;
using Microsoft.AspNetCore.Mvc;
using UserAcountManagement.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAcountManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountService _AcountService;
        public AcountController(IAcountService AcountService)
        {
            _AcountService = AcountService;
        }

        [HttpPost("AddNewAcount")]
        public async Task<ActionResult<bool>> AddNewAcount([FromBody] AcountDTO acountDTO)
        {
            try
            {

                return Ok(await _AcountService.PostAcount(acountDTO));

            }
            catch
            {
                return false;
            }
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
         
}
