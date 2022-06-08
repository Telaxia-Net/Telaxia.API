namespace texlaxia_backend.Telaxia.Domain.Models;

public class Purchase
{
     public int Id { get; set; }
     
     public float Amount { get; set; }
     
     public int PayMethod { get; set; }
     
     public Buyer Buyer { get; set; }
     public int BuyerId { get; set; }
     
     public Design Design { get; set; }
     public int DesignId { get; set; }

}