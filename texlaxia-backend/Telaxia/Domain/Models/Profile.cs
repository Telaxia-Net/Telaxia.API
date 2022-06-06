using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        //Relationship
        public IList<Post> Posts { get; set; } = new List<Post>();
        public int UserId { get; set; }
        public User User { get; set; }

    }
}