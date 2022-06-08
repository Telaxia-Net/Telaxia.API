namespace texlaxia_backend.Telaxia.Resources;

public class PostResource
{
    public int Id { get; set; }
    public int PostLike { get; set; }
        
    public string Description { get; set; }
        
    public string Title { get; set; }

    public int DesignerId { get; set; }
    
}