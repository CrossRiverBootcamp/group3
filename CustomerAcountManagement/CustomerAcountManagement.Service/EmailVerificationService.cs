using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CustomerAcountManagement.Service;

public class EmailVerificationService : IEmailVerificationService
{
    private readonly IEmailVerificationStorage _emailVerificationStorage;
    private readonly IEmailSender _emailSender;
    public EmailVerificationService(IEmailVerificationStorage emailVerificationStorage, IEmailSender emailSender)
    {
        _emailVerificationStorage = emailVerificationStorage;
        _emailSender=emailSender;
    }
    public async Task<bool> GetEmailVerification(string email,string verificationCode)
    {
        return await _emailVerificationStorage.GetEmailVerification(email,verificationCode);
    }

    public async Task VerificateEmail(string email)
    {
        Random rand=new();
        string verificationCode = "";
        for(int i=0;i<4;i++)
            verificationCode+=rand.Next(10).ToString();
        EmailVerification emailVerification = new()
        {
            Email = email,
            VerificationCode = verificationCode,
            ExpirationTime = DateTime.Now.AddMinutes(5)
        };
        await _emailVerificationStorage.PostEmailVerification(emailVerification);
        _emailSender.SendEmailAsync(email, "verification code", emailVerification.VerificationCode);

    }
    public async Task CleanEmailVerificationTable()
    {
        _emailVerificationStorage.CleanEmailVerificationTable();
    }
}
