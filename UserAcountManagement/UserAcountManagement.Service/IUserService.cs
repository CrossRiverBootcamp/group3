
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public interface IUserService
{
    public Task<bool> PostCustomer(Customer newCustomer);
    public Task<int> LogIn(string email, string password);

}
