
using DTO;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public interface IUserService
{
    public Task<bool> PostCustomer(RegisterDTO registerDTO);
    public Task<int> LogIn(string email, string password);

}
