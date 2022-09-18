using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAcountManagement.Storage.Entities;

public class Acount
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public DateTime OpenDate { get; set; }=DateTime.Now;
    public int Balance { get; set; } = 1000;
    public virtual Customer Customer { get; set; }

}
