
using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;

public class CustomerService : ICustomerService
{
    private readonly IAcountStorage _AcountStorage;
    private readonly ICustomerStorage _customerStorage;
    private readonly IMapper _mapper;
    public CustomerService(IAcountStorage acount, ICustomerStorage customer, IMapper mapper)
    {
        _AcountStorage = acount;
        _customerStorage = customer;
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

            Customer customer = _mapper.Map<Customer>(registerDTO);
            string existingEmail = await _customerStorage.ValidateUniqueEmail(customer.Email);
            if (existingEmail != null)
                throw new Exception("Email exists");
            await _customerStorage.Register(customer);
            try
            {
                Acount acount = new Acount();
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
