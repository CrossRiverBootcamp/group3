
using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace CustomerAcountManagement.Service;

public class CustomerService : ICustomerService
{
    private readonly IAcountStorage _acountStorage;
    private readonly ICustomerStorage _customerStorage;
    private readonly IEmailVerificationService _emailVerificationService;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    public CustomerService(IAcountStorage acount, ICustomerStorage customer,IEmailVerificationService emailVerificationService, IMapper mapper, IConfiguration config)
    {
        _acountStorage = acount;
        _customerStorage = customer;
        _emailVerificationService = emailVerificationService;
        _config= config;
        _mapper = mapper;
    }

    public async Task<CustomerTokenDTO> LogIn(string email, string password)
    {
        try
        {
            Customer customer = await _customerStorage.LogIn(email, password);
            if (customer != null)
            {
                int acountId= await _acountStorage.GetAcountIdByCustomerId(customer.Id);
                CustomerTokenDTO customerToken = new();
                customerToken.AcountId = acountId;
               customerToken.Token=await generateJsonWebToken(customerToken);
                return customerToken;
            }
              
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public async Task<bool> PostCustomer(RegisterDTO registerDTO)
    {
        try
        {

            Customer customer = _mapper.Map<Customer>(registerDTO);
            string existingEmail = await _customerStorage.ValidateUniqueEmail(customer.Email);
            if (existingEmail != null)
                throw new Exception("Email exists");
            await _customerStorage.Register(customer);
            try
            {
                Storage.Entities.Acount acount = new Storage.Entities.Acount();
                acount.CustomerId = customer.Id;
                await _acountStorage.CreateAcount(acount);
            }
            catch
            {
                while (true)
                {
                    try
                    {
                        await _customerStorage.DeleteCustomer(customer);

                        return false;
                    }
                    catch
                    {
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }

    }
    public async Task<string> generateJsonWebToken(CustomerTokenDTO customer)
    {

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new ("AcountId", customer.AcountId.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = credentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
