using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class HomeController : Controller
    {
    private MyContext _context;

    public HomeController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}