using System.ComponentModel.DataAnnotations;

namespace CustomerAcountManagement.Storage.Entities;

public class EmailVerification
{
    [Key]
    public string Email { get; set; }
    public string VerificationCode { get; set; }
    public DateTime ExpirationTime { get; set; }
}
