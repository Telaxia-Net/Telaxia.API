namespace texlaxia_backend.Telaxia.Domain.Models;

public class DesignCollaborator
{
    public Design Design { get; set; }
    public int DesignId { get; set; }
    
    public Collaborator Collaborator { get; set; }
    public int CollaboratorId { get; set; }
    
    public string Description { get; set; }
    public string Name { get; set; }
}