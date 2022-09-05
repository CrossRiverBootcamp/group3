
using System.ComponentModel.DataAnnotations;


namespace DTO;

public class LogInDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string CustomerPassword { get; set; }
}
