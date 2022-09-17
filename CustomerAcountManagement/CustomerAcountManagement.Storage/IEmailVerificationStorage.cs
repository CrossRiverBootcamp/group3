

using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Storage;

public interface IEmailVerificationStorage
{
    public Task PostEmailVerification(EmailVerification verification);
    public Task<bool> GetEmailVerification(string email,string verificationCode);
    public Task CleanEmailVerificationTable();
}
