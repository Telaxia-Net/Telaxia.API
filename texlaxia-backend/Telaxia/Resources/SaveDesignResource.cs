namespace texlaxia_backend.Telaxia.Resources;

public class SaveDesignResource
{
    public int DesignerId { get; set; }

    public string DesignViewUrl { get; set; }
    
    public string ImageDesign { get; set; }
    
    public bool Visibility { get; set; }
}