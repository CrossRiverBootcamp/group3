
using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CustomerAcountManagement.Service;

public class CustomerService : ICustomerService
{
    private readonly IAcountStorage _AcountStorage;
    private readonly ICustomerStorage _customerStorage;
    private readonly IEmailVerificationService _emailVerificationService;
    private readonly IMapper _mapper;
    public CustomerService(IAcountStorage acount, ICustomerStorage customer,IEmailVerificationService emailVerificationService, IMapper mapper)
    {
        _AcountStorage = acount;
        _customerStorage = customer;
        _emailVerificationService = emailVerificationService;
        _mapper = mapper;
    }

    public async Task<int> LogIn(string email, string password)
    {
        try
        {
            Customer customer = await _customerStorage.LogIn(email, password);
            if (customer != null)
                return await _AcountStorage.GetAcountIdByCustomerId(customer.Id);
            return 0;
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
            bool verified = await _emailVerificationService.GetEmailVerification(registerDTO.Email, registerDTO.VerificationCode);
            if (!verified)
                throw new Exception("Please use a verification code");
            Customer customer = _mapper.Map<Customer>(registerDTO);
            string existingEmail = await _customerStorage.ValidateUniqueEmail(customer.Email);
            if (existingEmail != null)
                throw new Exception("Email exists");
            await _customerStorage.Register(customer);
            try
            {
                Storage.Entities.Acount acount = new Storage.Entities.Acount();
                acount.CustomerId = customer.Id;
                await _AcountStorage.CreateAcount(acount);
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

}
