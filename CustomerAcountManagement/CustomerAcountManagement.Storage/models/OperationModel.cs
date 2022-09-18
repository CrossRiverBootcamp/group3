

namespace CustomerAcountManagement.Storage.models;

public class OperationModel
{   
    public bool Debit { get; set; }
  
    public int ThirdParty { get; set; }
  
    public int Amount { get; set; }
 
    public int Balance { get; set; }
    public DateTime Date { get; set; }
    
}
