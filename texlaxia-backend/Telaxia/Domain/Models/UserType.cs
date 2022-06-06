namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
    }
}