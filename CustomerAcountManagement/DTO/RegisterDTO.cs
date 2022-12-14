
using System.ComponentModel.DataAnnotations;

namespace DTO;

public class RegisterDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string VerificationCode { get; set; }
}
