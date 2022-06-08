namespace Telaxia_Backend.Telaxia.Domain.Models;

public class DesignCollaborator
{
    public Design Design { get; set; }
    public int DesignId { get; set; }
    
    public Collaborator Collaborator { get; set; }
    public int CollaboratorId { get; set; }
    
    public string description { get; set; }
    public string name { get; set; }
}