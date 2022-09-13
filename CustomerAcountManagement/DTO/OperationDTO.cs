using System.ComponentModel.DataAnnotations;

namespace DTO;

public class OperationDTO
{
    [Required]
    public bool Debit { get; set; }
    [Required]
    public int ThirdParty { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public int Balance { get; set; }
    public DateTime Date { get; set; }
}
