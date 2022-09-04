
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Storage;

public class UserStorage : IUserStorage
{
    public Task<string> LogIn(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<string> Register(User user)
    {
        throw new NotImplementedException();
    }
}
