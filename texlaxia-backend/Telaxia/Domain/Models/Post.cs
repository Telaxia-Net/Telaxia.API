using System.Collections.Generic;

namespace texlaxia_backend.Telaxia.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int PostLike { get; set; }
        
        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public Designer Designer { get; set; }
        
        public int DesignerId { get; set; }
        
        //Relationship one to many
        public List<Comment> Comments { get; set; } = new List<Comment>();
        
        //Relationship one to many
        public List<PostDesign> PostDesigns { get; set; } = new List<PostDesign>();
    }
}