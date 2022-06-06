using System.Collections.Generic;

namespace Telaxia_Backend.Telaxia.Domain.Models;
public class Date
{
    public int Id { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    //Relationship
    public IList<Design> Designs_DateCreated { get; set; } = new List<Design>();
    public IList<Design> Designs_DateEdited { get; set; } = new List<Design>();
    public IList<Post> Posts { get; set; } = new List<Post>();
}
