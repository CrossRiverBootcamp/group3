
using DTO;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;

public interface ICustomerService
{
    public Task<bool> PostCustomer(RegisterDTO registerDTO);
    public Task<CustomerTokenDTO> LogIn(string email, string password);

}
