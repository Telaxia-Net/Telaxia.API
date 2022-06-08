using System.Collections.Generic;
using System.Net.Mime;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Telaxia_Backend.Telaxia.Domain.Models;

public class Design
{
    public int Id { get; set; }

    public Designer Designer { get; set; }
    
    public int DesignerId { get; set; }

    public String DesignViewUrl { get; set; }
    
    //public DataType.Image ImageDesign { get; set; }
    
    public bool Visibility { get; set; }
    
    //Relationship one to many
    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    
    //Relationship one to many
    public List<PostDesign> PostDesigns { get; set; } = new List<PostDesign>();
    
    //Relationship one to many
    public List<DesignCollaborator> DesignCollaborators { get; set; } = new List<DesignCollaborator>();
}
