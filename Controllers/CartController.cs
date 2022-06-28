using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class CartController : Controller
    {
    private MyContext _context;

    public CartController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("cart")]
    public IActionResult UserCart()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            User user = _context.Users
            .Include(u => u.Cart)
            .ThenInclude(pic => pic.Product)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.User = user;

            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("cart/add/{ProductId}")]
    public IActionResult AddToCart(int ProductId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            string prevUrl = Request.Headers["Referer"].ToString();
            User user = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            List<ProductsInCart> currentCart = user.Cart;

            if(!currentCart.Any(p => p.ProductId == ProductId))
            {
                ProductsInCart addedProduct = new ProductsInCart();
                addedProduct.ProductId = ProductId;
                addedProduct.UserId = (int)HttpContext.Session.GetInt32("UserId");
                addedProduct.OrderedQuantity = 1;
                _context.Add(addedProduct);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("NumCartItems", user.Cart.Count);
                return Redirect(prevUrl);
            }
            else
            {
                ProductsInCart productInCart = currentCart.FirstOrDefault(p => p.ProductId == ProductId);
                productInCart.OrderedQuantity++;
                _context.SaveChanges();
                HttpContext.Session.SetInt32("NumCartItems", user.Cart.Sum(p => p.OrderedQuantity));
                return Redirect(prevUrl);
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("cart/subtract/{ProductId}")]
    public IActionResult SubtractFromCart(int ProductId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            string prevUrl = Request.Headers["Referer"].ToString();

            User user = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            List<ProductsInCart> currentCart = user.Cart;

            if(currentCart.Any(p => p.ProductId == ProductId) == null)
            {
                return Redirect(prevUrl);
            }
            else
            {
                ProductsInCart productInCart = currentCart.FirstOrDefault(p => p.ProductId == ProductId);

                Console.WriteLine(productInCart.OrderedQuantity);

                if(productInCart.OrderedQuantity > 1)
                {
                    productInCart.OrderedQuantity--;
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("NumCartItems", user.Cart.Sum(p => p.OrderedQuantity));
                    return Redirect(prevUrl);
                }
                else
                {
                    return Redirect(prevUrl);
                }
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("cart/remove/{ProductsInCartId}")]
    public IActionResult RemoveFromCart(int ProductsInCartId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            ProductsInCart pic = _context.ProductsInCarts
            .FirstOrDefault(a => a.ProductsInCartId == ProductsInCartId);

            if(pic.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                int NumCartItems = (int)HttpContext.Session.GetInt32("NumCartItems");
                NumCartItems -= pic.OrderedQuantity;
                HttpContext.Session.SetInt32("NumCartItems", NumCartItems);
                _context.Remove(pic);
                _context.SaveChanges();
                return RedirectToAction("UserCart");
            }
            else
            {
                return RedirectToAction("UserCart");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }
}