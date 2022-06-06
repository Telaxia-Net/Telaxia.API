using System.Collections.Generic;

namespace Telaxia_Backend.Telaxia.Domain.Models;
public class Design
{
    public int Id { get; set; }
    //Relationship
    public Cooperative Cooperative { get; set; }
    public int DateCreatedId { get; set; }
    public Date DateCreated { get; set; }
    public int DateEditedId { get; set; }
    public Date DateEdited { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Post Post { get; set; }
}
