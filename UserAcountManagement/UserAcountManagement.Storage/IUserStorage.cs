
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public interface IUserStorage
{
    public Task<Customer> Register(Customer user);
    public Task<Customer> LogIn(string email, string password);
    public Task DeleteCustomer(Customer customer);
    public Task<string> ValidateUniqueEmail(string email);
}
