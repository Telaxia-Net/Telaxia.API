using System.Collections.Generic;

namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int PostLike { get; set; }
        //RelationShip
        public Information Information;
        public int DatePostedId { get; set; }
        public Date DatePosted { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int DesignId { get; set; }
        public Design Design { get; set; }
    }
}