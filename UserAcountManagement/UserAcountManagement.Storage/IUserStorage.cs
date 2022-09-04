
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public interface IUserStorage
{
    public Task<string> Register(User user);
    public Task<string> LogIn(string email, string password);
}
