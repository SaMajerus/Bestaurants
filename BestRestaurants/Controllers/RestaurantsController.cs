using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller 
  { 

    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db) 
    {
      _db = db; 
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Type).ToList(); 
    }

    public ActionResult Create()
    {
      return View(); 
    }

    [HttpPost]
    public ActionResult Create(Type type)
    {
      _db.Types.Add(type); 
      _db.SaveChanges(); 
      return RedirectToAction("Index"); 
    }

    public ActionResult Show(int id)
    {
      Type thisType = _db.Types.FirstOrDefault(type => type.Type == id); 
      return View(thisType);
    }

    public ActionResult Edit(int id)
    {
      Type thisType = _db.Types.FirstOrDefault(type => type.TypeId == id); 
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(Type type)
    {
      _db.Types.Add(type); 
      _db.SaveChanges(); 
      return RedirectToAction("Index"); 
    }

    public ActionResult Delete(int id)
    {
      Type thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      return View(thisType);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Type thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      _db.Types.Remove(type); 
      _db.SaveChanges(); 
      return RedirectToAction("Index"); 
    }
  }
}