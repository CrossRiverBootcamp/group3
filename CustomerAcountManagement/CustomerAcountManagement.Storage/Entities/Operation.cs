using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAcountManagement.Storage.Entities;

public class Operation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [ForeignKey("Acount")]
    public int AcountId { get; set; }
    [Required]
    public Guid TransactionId { get; set; }
    [Required]

    public bool Debit { get; set; }
    [Required]

    public int TransactionAmount { get; set; }
    [Required]

    public int Balance { get; set; }
    [Required]

    public DateTime OperationTime { get; set; }

    public Acount Acount { get; set; }
}
