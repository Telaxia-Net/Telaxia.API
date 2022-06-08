﻿using System.Collections.Generic;

namespace Telaxia_Backend.Telaxia.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Phone{ get; set; }
        public string Mail{ get; set; }
        
        public int Rating { get; set; }
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
        
        //Relationship one to many
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}