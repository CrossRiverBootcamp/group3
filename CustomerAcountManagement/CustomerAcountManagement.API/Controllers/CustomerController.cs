using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using CustomerAcountManagement.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAcountManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _CustomerService;
    private readonly IEmailVerificationService _EmailVerificationService;
    public CustomerController(ICustomerService CustomerService,IEmailVerificationService emailVerificationService)
    {
        _CustomerService = CustomerService;
        _EmailVerificationService = emailVerificationService;

    }
    [HttpGet("{email}")]
    public async Task<ActionResult> VerificateEmail(string email)
    {
        _EmailVerificationService.VerificateEmail(email);
        return Ok();
    }
    [HttpPost("Register")]
    public async Task<ActionResult<bool>> Register([FromBody] RegisterDTO registerDTO)
    {
        try
        {

            return Ok(await _CustomerService.PostCustomer(registerDTO));

        }
        catch
        {
            return Unauthorized();
        }
    }
    [HttpPost("Login")]
    public async Task<ActionResult<int>> LogIn([FromBody] LogInDTO logInDTO)
    {
        try
        {

            int acountId = await _CustomerService.LogIn(logInDTO.Email, logInDTO.CustomerPassword);
            if (acountId == 0)
                throw new Exception("Customer name or password are incorect");
            return Ok(acountId);

        }
        catch
        {
            return Unauthorized();
        }
    }
}
