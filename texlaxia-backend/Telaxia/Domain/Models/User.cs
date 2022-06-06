using System.Collections.Generic;

namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string LastName{ get; set; }
        public int Phone{ get; set; }
        public string Mail{ get; set; }
        //Relationship
        public List<Cooperative> Cooperatives { get; set; }
        public List<Design>Designs { get; set; }
        public List<Profile>Profiles { get; set; }
        public int UserTypeId{ get; set; }
        public UserType UserType{ get; set; }
        public int PlanId { get; set; }
        public Plan Plan{ get; set; }
    }
}