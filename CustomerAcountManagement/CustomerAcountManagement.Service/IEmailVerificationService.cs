

namespace CustomerAcountManagement.Service;

public interface IEmailVerificationService
{
    public Task VerificateEmail(string email);
    public Task<bool> GetEmailVerification(string email, string verificationCode);
    public Task CleanEmailVerificationTable();
}
