using System.Collections.Generic;

namespace BestRestaurants.Models
{
  public class Type
  {
    public Type()
    {
      this.Restaurants = new HashSet<Restaurant>();
    }

    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public virtual ICollection<Restaurant> Restaurants { get; set; }
  }
}