namespace Telaxia_Backend.Telaxia.Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public DateTime date { get; set; }
    public string body { get; set; }
    
    public User User { get; set; }
    public int UserId { get; set; }
    
    public Post Post { get; set; }
    public int PostId { get; set; }
}