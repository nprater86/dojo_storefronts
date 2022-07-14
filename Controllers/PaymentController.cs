using Microsoft.AspNetCore.Mvc;
using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class PaymentController : Controller
    {
    private MyContext _context;

    public PaymentController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("payments/add")]
    public IActionResult AddPayment()
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
    public IActionResult SavePayment(Payment newPayment)
    {
        if(ModelState.IsValid)
        {
            if(newPayment.Name == null)
            {
                newPayment.Name = newPayment.Company + " ending in " + newPayment.Number.Substring(12);
            }

            newPayment.UserId = (int)HttpContext.Session.GetInt32("UserId");

            _context.Add(newPayment);
            _context.SaveChanges();
            return RedirectToAction("Account","User");
        }
        else
        {
            return View("AddPayment");
        }
    }

    [HttpGet("payments/{PaymentId}/delete")]
    public IActionResult DeleteAddress(int PaymentId)
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            Payment paymentInDb = _context.Payments
            .FirstOrDefault(p => p.PaymentId == PaymentId);

            if(paymentInDb.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                _context.Remove(paymentInDb);
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