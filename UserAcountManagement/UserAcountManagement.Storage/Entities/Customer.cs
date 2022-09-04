
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserAcountManagement.Storage.Entities;

[Index("Email", IsUnique = true)]

public class Customer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(30)]
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [MinLength(8)]
    [Required]
    public string Password { get; set; }
}
