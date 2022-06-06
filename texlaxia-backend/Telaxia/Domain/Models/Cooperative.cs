using Microsoft.EntityFrameworkCore;
using Telaxia_Backend.Telaxia.Domain.Models;
public class Cooperative
{
    public int Id;
    public string Host { get; set; }
    public string Editor { get; set; }
    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
    public int DesignId { get; set; }
    public Design Design { get; set; }
    
}
