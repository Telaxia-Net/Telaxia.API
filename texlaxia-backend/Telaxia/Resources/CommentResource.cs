namespace texlaxia_backend.Telaxia.Resources;

public class CommentResource
{
    public int Id { get; set; }
    public DateTime date { get; set; }
    public string body { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}