using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class StorefrontController : Controller
    {
    private MyContext _context;

    public StorefrontController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("storefronts/mystorefront")]
    public IActionResult MyStorefront()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");

            Storefront storeInDb = _context.Storefronts
            .Include(s => s.Inventory)
            .Include(s => s.SubmittedOrders)
            .FirstOrDefault(s => s.UserId == UserId);

            ViewBag.StoreFront = storeInDb;
            ViewBag.ActiveOrders = storeInDb.SubmittedOrders.Where(s => s.Status != "Complete").ToList();
            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("/storefronts/browse")]
    public IActionResult Browse()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            List<Storefront> AllStorefronts = _context.Storefronts
            .Include(s => s.Owner)
            .ToList();
            
            ViewBag.AllStorefronts = AllStorefronts;
            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("/storefronts/{StorefrontId}")]
    public IActionResult Storefront(int StorefrontId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Storefront Storefront = _context.Storefronts
            .Include(s => s.Owner)
            .Include(s => s.Inventory)
            .FirstOrDefault(s => s.StorefrontId == StorefrontId);
            
            if(Storefront != null)
            {
                return View(Storefront);
            }
            else
            {
                return RedirectToAction("Browse");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("storefronts/create")]
    public IActionResult Create()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpPost]
    public IActionResult SaveStorefront(Storefront newStorefront)
    {
        if(ModelState.IsValid)
        {
            newStorefront.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newStorefront);
            _context.SaveChanges();
            return RedirectToAction("MyStorefront");
        }
        else
        {
            return View("Create");
        }
    }

    [HttpGet("storefronts/{StorefrontId}/edit")]
    public IActionResult EditStorefront(int StorefrontId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Storefront storefrontInDb = _context.Storefronts
            .Include(s => s.Owner)
            .FirstOrDefault(s => s.StorefrontId == StorefrontId);

            if(storefrontInDb.Owner.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                return View(storefrontInDb);
            }
            else
            {
                return RedirectToAction("MyStorefront");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpPost]
    public IActionResult UpdateStorefront(Storefront updatedStorefront)
    {
        Storefront retrievedStorefront = _context.Storefronts
        .FirstOrDefault(s => s.StorefrontId == updatedStorefront.StorefrontId);

        retrievedStorefront.Title = updatedStorefront.Title;
        retrievedStorefront.Description = updatedStorefront.Description;
        _context.SaveChanges();

        return RedirectToAction("MyStorefront");
    }

    [HttpGet("storefronts/mystorefront/manageorders")]
    public IActionResult ManageOrders()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");

            Storefront storeInDb = _context.Storefronts
            .Include(s => s.Inventory)
            .Include(s => s.SubmittedOrders)
            .ThenInclude(so => so.Products)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(s => s.UserId == UserId);

            ViewBag.StoreFront = storeInDb;
            ViewBag.ActiveOrders = storeInDb.SubmittedOrders.Where(s => s.Status != "Complete").ToList();
            ViewBag.CompletedOrders = storeInDb.SubmittedOrders.Where(s => s.Status == "Complete").ToList();

            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("storefronts/mystorefront/manageorders/{SubmittedOrderId}")]
    public IActionResult ManageOrder(int SubmittedOrderId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            SubmittedOrder order = _context.SubmittedOrders
            .Include(o => o.Products)
            .ThenInclude(p => p.Product)
            .Include(o => o.Storefront)
            .Include(o => o.Payment)
            .Include(o => o.ShippingAddress)
            .FirstOrDefault(o => o.SubmittedOrderId == SubmittedOrderId);

            if(order.Storefront.UserId == HttpContext.Session.GetInt32("UserId"))
            {

                return View(order);
            }
            else
            {
                return RedirectToAction("ManageOrders");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }
}