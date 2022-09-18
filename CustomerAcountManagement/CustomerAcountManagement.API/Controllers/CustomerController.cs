using DTO;
using Microsoft.AspNetCore.Mvc;
using CustomerAcountManagement.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAcountManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IEmailVerificationService _emailVerificationService;
    public CustomerController(ICustomerService customerService,IEmailVerificationService emailVerificationService)
    {
        _customerService = customerService;
        _emailVerificationService = emailVerificationService;

    }
    [HttpGet("{email}")]
    public async Task<ActionResult> VerificateEmail(string email)
    {
        _emailVerificationService.VerificateEmail(email);
        return Ok();
    }
    [HttpPost("Register")]
    public async Task<ActionResult<bool>> Register([FromBody] RegisterDTO registerDTO)
    {
        try
        {

            return Ok(await _customerService.PostCustomer(registerDTO));

        }
        catch
        {
            return Unauthorized();
        }
    }
    [HttpPost("Login")]
    public async Task<ActionResult<CustomerTokenDTO>> LogIn([FromBody] LogInDTO logInDTO)
    {
        try
        {

            CustomerTokenDTO customerToken = await _customerService.LogIn(logInDTO.Email, logInDTO.CustomerPassword);
            if (customerToken == null)
                throw new Exception("Customer name or password are incorect");
            return Ok(customerToken);

        }
        catch
        {
            return Unauthorized();
        }
    }
}
