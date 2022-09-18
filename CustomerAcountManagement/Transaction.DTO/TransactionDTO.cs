using System.ComponentModel.DataAnnotations;


namespace Transaction.DTO;

public class TransactionDTO
{
    [Required]
    public int FromAcountID { get; set; }
    [Required]
    public int ToAcountID { get; set; }
    [Required]
    public int Amount { get; set; }
}
