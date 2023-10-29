using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using System.Security.Cryptography;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private DishesContext _context;
    public HomeController(ILogger<HomeController> logger, DishesContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public IActionResult IndexView()
    {
        List<Dish> ListaPlatos = _context.Dishes.ToList();
        ViewBag.Platos = ListaPlatos;
        return View("Index");
    }

    [HttpGet("dishes/{DishID}")]
    public IActionResult SelectDish(int dishID)
    {
        Dish? seletedDish = _context.Dishes.FirstOrDefault(plt => plt.DishId == dishID);
        ViewBag.onePlato = seletedDish;
        return View("DishView");
    }

    [HttpPost("{DishID}/delete")]
    public IActionResult DeleteDish(int dishID)
    {
        Dish? seletedDish = _context.Dishes.SingleOrDefault(plt => plt.DishId == dishID);
        _context.Dishes.Remove(seletedDish);
        _context.SaveChanges();

        return RedirectToAction("index");
    }
    [HttpGet("dishes/{DishID}/edit")]
    public IActionResult EditDish(int dishID)
    {
        Dish? seletedDish = _context.Dishes.FirstOrDefault(plt => plt.DishId == dishID);
        ViewBag.cargaForm = seletedDish;

        return View("EditDishView");

    }
    [HttpPost("dishes/{DishID}/update")]
    public IActionResult UpdateDish(Dish newDish, int dishID)
    {
        Dish? seletedDish = _context.Dishes.FirstOrDefault(plt => plt.DishId == dishID);
        ViewBag.cargaForm = seletedDish;
        ViewBag.onePlato = seletedDish;
        if (ModelState.IsValid)
        {
            seletedDish.Name = newDish.Name;
            seletedDish.Chef = newDish.Chef;
            seletedDish.Calories = newDish.Calories;
            seletedDish.Tastinness = newDish.Tastinness;
            seletedDish.Description = newDish.Description;
            seletedDish.UpdateAt = DateTime.Now;
            _context.SaveChanges();
            return View("DishView", dishID);
        }
        else
        {
            return View("EditDishView", seletedDish);
        }

    }
    [HttpGet("dishes/new")]
    public IActionResult RAddDish()
    {
        return View("AddDish");

    }
    [HttpPost("dishes/create")]
    public IActionResult AddDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddDish", newDish);
        }

    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
