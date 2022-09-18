using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Storage;

public interface ICustomerStorage
{
    public Task<Customer> Register(Customer Customer);
    public Task<Customer> LogIn(string email, string password);
    public Task DeleteCustomer(Customer customer);
    public Task<string> ValidateUniqueEmail(string email);
   
}
