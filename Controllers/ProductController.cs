using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class ProductController : Controller
    {
    private MyContext _context;

    public ProductController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/products/{ProductId}")]
    public IActionResult ProductDetail(int ProductId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Product productInDb = _context.Products
            .Include(p => p.HomeStorefront)
            .ThenInclude(s => s.Owner)
            .FirstOrDefault(p => p.ProductId == ProductId);

            if(productInDb != null)
            {
                return View(productInDb);
            }
            else
            {
                return RedirectToAction("Dashboard","Home");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpPost]
    public IActionResult SaveProduct(Product newProduct)
    {
        Storefront storeInDb = _context.Storefronts
        .Include(s => s.Inventory)
        .Include(s => s.SubmittedOrders)
        .FirstOrDefault(s => s.UserId == HttpContext.Session.GetInt32("UserId"));
        newProduct.StorefrontId = storeInDb.StorefrontId;

        if(ModelState.IsValid)
        {  
            _context.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("MyStorefront","Storefront");
        }
        else
        {
            ViewBag.StoreFront = storeInDb;
            return View("../Storefront/MyStorefront");
        }
    }

    [HttpGet("products/{ProductId}/edit")]
    public IActionResult EditProduct(int ProductId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Product productInDb = _context.Products
            .Include(p => p.HomeStorefront)
            .FirstOrDefault(p => p.ProductId == ProductId);

            if(productInDb != null)
            {
                if(productInDb.HomeStorefront.UserId == HttpContext.Session.GetInt32("UserId"))
                {
                    return View(productInDb);
                }
                else
                {
                    return RedirectToAction("MyStorefront","Storefront");
                }
            }
            else
            {
                return RedirectToAction("MyStorefront","Storefront");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpPost]
    public IActionResult UpdateProduct(Product updatedProduct)
    {
        Product retrievedProduct = _context.Products
        .FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);

        retrievedProduct.Name = updatedProduct.Name;
        retrievedProduct.Description = updatedProduct.Description;
        retrievedProduct.Price = updatedProduct.Price;
        retrievedProduct.Quantity = updatedProduct.Quantity;
        retrievedProduct.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return RedirectToAction("MyStorefront","Storefront");
    }

    [HttpGet("products/{ProductId}/delete")]
    public IActionResult DeleteProduct(int ProductId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Product productInDb = _context.Products
            .Include(p => p.HomeStorefront)
            .FirstOrDefault(p => p.ProductId == ProductId);
            
            if(productInDb.HomeStorefront.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                _context.Products.Remove(productInDb);
                _context.SaveChanges();

                return RedirectToAction("MyStorefront","Storefront");
            }
            else
            {
                return RedirectToAction("MyStorefront","Storefront");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }
}