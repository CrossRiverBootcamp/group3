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
    public int FromAccountID { get; set; }
    [Required]
    public int ToAccountID { get; set; }
    [Required]
    public int Amount { get; set; }
}
