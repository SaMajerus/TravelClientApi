using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class PlacesController : Controller
  {
    public IActionResult Index()
    {
      var allPlaces = Place.GetPlaces();   //Issue here apparently
      return View(allPlaces);
    }

    [HttpPost]
    public IActionResult Index(Place place)
    {
      Place.Post(place);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }

    public IActionResult Edit(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }

    [HttpPost]
    public IActionResult Details(int id, Place place)
    {
      place.PlaceId = id;
      Place.Put(place);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Place.Delete(id);
      return RedirectToAction("Index");
    }
  }
}