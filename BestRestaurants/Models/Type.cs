using System.Collections.Generic;

namespace BestRestaurants.Models
{
  public class Type
  {
    public Type()
    {
      this.Restaurants = new HashSet<Restuarant>();
    }

    public int TypeId { get; set; }
    public string Type { get; set; }
    public virtual ICollection<Restaurant> Restaurants { get; set; }
  }
}