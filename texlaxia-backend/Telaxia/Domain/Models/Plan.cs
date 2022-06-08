namespace texlaxia_backend.Telaxia.Domain.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
        public string Description { get; set; }
        
        //Relationship one to many
        public List<User> Users { get; set; } = new List<User>();
    }
}