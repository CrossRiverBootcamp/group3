
using CustomerAcountManagement.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAcountManagement.Storage;

public class EmailVerificationStorage : IEmailVerificationStorage
{
    private readonly IDbContextFactory<BankDBContext> _dbContextFactory;
    public EmailVerificationStorage(IDbContextFactory<BankDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task PostEmailVerification(EmailVerification verification)
    {
        if (verification == null)
            throw new ArgumentNullException(nameof(verification));
        var dbContext = _dbContextFactory.CreateDbContext();
        EmailVerification exitingEmailVerification=dbContext.EmailVerifications.FirstOrDefault(emailVerification => emailVerification.Email.Equals(verification.Email));
       if(exitingEmailVerification == null)
        dbContext.EmailVerifications.Add(verification);
        else
        {
            exitingEmailVerification.VerificationCode=verification.VerificationCode;
            exitingEmailVerification.ExpirationTime=verification.ExpirationTime;
            dbContext.EmailVerifications.Update(exitingEmailVerification);
        }
        await dbContext.SaveChangesAsync();
    }
    public async Task<bool> GetEmailVerification(string email, string verificationCode)
    {
        var dbContext = _dbContextFactory.CreateDbContext();
        EmailVerification emailVerification =await dbContext.EmailVerifications
            .FirstOrDefaultAsync(emailVerification => emailVerification.Email.Equals(email)&&emailVerification.VerificationCode.Equals(verificationCode));
        if (emailVerification == null|| DateTime.Compare(emailVerification.ExpirationTime,DateTime.Now) < 0)
            return false;
        return true;
    }
    public async Task CleanEmailVerificationTable()
    {
        DateTime now = DateTime.Now;
        var dbContext=_dbContextFactory.CreateDbContext();
        foreach(EmailVerification emailVerification in dbContext.EmailVerifications)
        {
            if (DateTime.Compare(emailVerification.ExpirationTime, now) < 0)
                dbContext.EmailVerifications.Remove(emailVerification);
        }
       await dbContext.SaveChangesAsync();

    }

}
