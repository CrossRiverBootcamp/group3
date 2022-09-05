using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DTO;

public class AcountInfoDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public int AcountId { get; set; }
    public DateTime OpenDate { get; set; }
    public int Balance { get; set; }

}
