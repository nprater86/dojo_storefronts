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
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View();
        }
    }
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            User userInDb = _context.Users
            .Include(u => u.SubmittedOrders)
            .ThenInclude(su => su.Products)
            .Include(u => u.SubmittedOrders)
            .ThenInclude(su => su.Storefront)
            .Include(u => u.SubmittedOrders)
            .ThenInclude(su => su.Products)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            ViewBag.User = userInDb;
            ViewBag.CurrentOrders = userInDb.SubmittedOrders.Where(s => s.Status != "Complete").ToList();
            ViewBag.CompletedOrders = userInDb.SubmittedOrders.Where(s => s.Status == "Complete").ToList();

            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpGet("dashboard/order/{SubmittedOrderId}")]
    public IActionResult ViewOrder(int SubmittedOrderId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {   
            SubmittedOrder order = _context.SubmittedOrders
            .Include(o => o.Products)
            .ThenInclude(p => p.Product)
            .Include(o => o.Storefront)
            .ThenInclude(s => s.Owner)
            .Include(o => o.Payment)
            .Include(o => o.ShippingAddress)
            .FirstOrDefault(o => o.SubmittedOrderId == SubmittedOrderId);

            if(order.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                return View(order);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
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