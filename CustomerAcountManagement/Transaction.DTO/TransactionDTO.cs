using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
