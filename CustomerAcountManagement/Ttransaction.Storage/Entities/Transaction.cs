
using System.ComponentModel.DataAnnotations;

namespace Ttransaction.Storage.Entities;

public class Transaction
{
    [Key]
    public string Id { get; set; }
    [Required]
    public int FromAccountID { get; set; }
    [Required]
    public int ToAccountID { get; set; }
    [Required]
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(100)]
    public Status status { get; set; }
    public string FailureReason { get; set; }
}
