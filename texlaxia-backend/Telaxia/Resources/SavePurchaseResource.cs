namespace texlaxia_backend.Telaxia.Resources;

public class SavePurchaseResource
{
     
    public float Amount { get; set; }
     
    public string PayMethod { get; set; }
    
    public int DesignId { get; set; }
    
    public int BuyerId { get; set; }
}