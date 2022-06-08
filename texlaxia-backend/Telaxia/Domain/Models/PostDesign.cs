namespace Telaxia_Backend.Telaxia.Domain.Models;

public class PostDesign
{
    public Post Post { get; set; }
    public int PostId { get; set; }
    
    public Design Design { get; set; }
    public int DesignId { get; set; }
}