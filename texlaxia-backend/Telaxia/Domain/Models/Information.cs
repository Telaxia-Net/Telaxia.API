using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class Information
    {
        public int Id { get; set; }
        public int Views { get; set; }
        public int PostLikesId { get; set; }
        public Post PostLikes { get; set; }
    }
}