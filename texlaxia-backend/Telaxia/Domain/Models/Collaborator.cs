namespace texlaxia_backend.Telaxia.Domain.Models;

public class Collaborator
{
    public Designer Designer { get; set; }
    public int DesignerId { get; set; }
    
    public bool Type { get; set; }
    
    //Relationship one to many
    public List<DesignCollaborator> DesignCollaborators { get; set; } = new List<DesignCollaborator>();
}