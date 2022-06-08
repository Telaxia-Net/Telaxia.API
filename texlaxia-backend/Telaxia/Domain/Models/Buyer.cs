using System.Diagnostics.CodeAnalysis;

namespace Telaxia_Backend.Telaxia.Domain.Models;

public class Buyer
{
    //Relationship one to one
    public User User { get; set; }
    public int UserId { get; set; }

    //Relationship one to many
    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
}