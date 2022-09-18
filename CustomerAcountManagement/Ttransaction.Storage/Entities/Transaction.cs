using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ttransaction.Storage.Entities;

public class Transaction
{
    
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public int FromAcountID { get; set; }
    [Required]
    public int ToAcountID { get; set; }
    [Required]
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(100)]
    public Status status { get; set; }
    public string? FailureReason { get; set; }
}
