
using UserAcountManagement.Storage;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public class UserService : IUserService
{
    private readonly IAcountStorage _AcountStorage;
    private readonly IUserStorage _UserStorage;
    public UserService(IAcountStorage acount, IUserStorage user)
    {
        _AcountStorage = acount;
        _UserStorage = user;
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
            throw new Exception("401");
        }
        
    }

    public async Task<bool> PostCustomer(Customer newCustomer)
    {
        try
        {
            Customer c = new Customer();
            c.FirstName = newCustomer.FirstName;
            c.LastName = newCustomer.LastName;
            c.Email = newCustomer.Email;
            c.Password = newCustomer.Password;
            string existingEmail = await _UserStorage.ValidateUniqueEmail(newCustomer.Email);
            if (existingEmail != null)
                throw new Exception("400");
            await _UserStorage.Register(c);
            try
            {
                Acount acount = new Acount();
                acount.CustomerId = c.Id;
                await _AcountStorage.CreateAcount(acount);
            }
            catch
            {
                await _UserStorage.DeleteCustomer(c);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
       
    }
    
}
