using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class ShippingAddressController : Controller
    {
    private MyContext _context;

    public ShippingAddressController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("addresses/add")]
    public IActionResult AddAddress()
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
    public IActionResult SaveAddress(ShippingAddress newAddress)
    {
        if(ModelState.IsValid)
        {
            if(newAddress.Name == null)
            {
                newAddress.Name = newAddress.Address1;
            }

            newAddress.UserId = (int)HttpContext.Session.GetInt32("UserId");

            _context.Add(newAddress);
            _context.SaveChanges();
            return RedirectToAction("Account","User");
        }
        else
        {
            return View("AddAddress");
        }
    }

    [HttpGet("addresses/{ShippingAddressId}/delete")]
    public IActionResult DeleteAddress(int ShippingAddressId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            ShippingAddress addressInDb = _context.ShippingAddresses
            .FirstOrDefault(a => a.ShippingAddressId == ShippingAddressId);

            if(addressInDb.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                _context.Remove(addressInDb);
                _context.SaveChanges();
                return RedirectToAction("Account","User");
            }
            else
            {
                return RedirectToAction("Account","User");
            }
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

}