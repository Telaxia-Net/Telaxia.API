namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public User User { get; set; }
    }
}