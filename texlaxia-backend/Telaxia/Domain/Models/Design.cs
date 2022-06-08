using System.Collections.Generic;
using System.Net.Mime;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace texlaxia_backend.Telaxia.Domain.Models;

public class Design
{
    public int Id { get; set; }

    public Designer Designer { get; set; }
    
    public int DesignerId { get; set; }

    public string DesignViewUrl { get; set; }
    
    public string ImageDesign { get; set; }
    
    public bool Visibility { get; set; }
    
    //Relationship one to many
    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    
    //Relationship one to many
    public List<PostDesign> PostDesigns { get; set; } = new List<PostDesign>();
    
    //Relationship one to many
    public List<DesignCollaborator> DesignCollaborators { get; set; } = new List<DesignCollaborator>();
}
