
using AutoMapper;
using DTO;
using UserAcountManagement.Storage;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public class UserService : IUserService
{
    private readonly IAcountStorage _AcountStorage;
    private readonly IUserStorage _UserStorage;
    private readonly IMapper _mapper;
    public UserService(IAcountStorage acount, IUserStorage user, IMapper mapper)
    {
        _AcountStorage = acount;
        _UserStorage = user;
        _mapper = mapper;
    }

    public async Task<int> LogIn(string email, string password)
    {
        try
        {
            Customer customer = await _UserStorage.LogIn(email, password);
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
            string existingEmail = await _UserStorage.ValidateUniqueEmail(customer.Email);
            if (existingEmail != null)
                throw new Exception("Email exists");
            await _UserStorage.Register(customer);
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
                        await _UserStorage.DeleteCustomer(customer);

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
