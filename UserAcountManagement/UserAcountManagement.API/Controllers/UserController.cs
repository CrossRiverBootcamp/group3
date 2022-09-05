using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using UserAcountManagement.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAcountManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
            
        }
        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {

                return Ok(await _UserService.PostCustomer(registerDTO));

            }
            catch
            {
                return Unauthorized();
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<int>> LogIn([FromBody]  LogInDTO logInDTO)
        {
            try
            {
                
                int acountId= (await _UserService.LogIn(logInDTO.Email, logInDTO.CustomerPassword));
                if (acountId == 0)
                    throw new Exception("User name or password are incorect");
                return Ok(acountId);

            }
            catch 
            {
                return Unauthorized();
            }
        }
    }
}
