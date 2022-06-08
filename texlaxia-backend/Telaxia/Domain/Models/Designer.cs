namespace texlaxia_backend.Telaxia.Domain.Models;

public class Designer
{
    public User User { get; set; }
    public int UserId { get; set; }
    
    //Relationship one to many
    public List<Collaborator> Collaborators { get; set; } = new List<Collaborator>();
    
    //Relationship one to many
    public List<Design> Designs { get; set; } = new List<Design>();
    
    //Relationship one to many
    public List<Post> Posts { get; set; } = new List<Post>();
}