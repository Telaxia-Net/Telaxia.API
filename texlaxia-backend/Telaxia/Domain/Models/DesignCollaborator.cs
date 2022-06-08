namespace texlaxia_backend.Telaxia.Domain.Models;

public class DesignCollaborator
{
    public string Description { get; set; }
    public string Name { get; set; }
    
    /*----------Relationship----------*/
    public Design Design { get; set; }
    public int DesignId { get; set; }
    
    public Collaborator Collaborator { get; set; }
    public int CollaboratorId { get; set; }
}