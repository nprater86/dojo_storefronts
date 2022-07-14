using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class UserController : Controller
    {
    private MyContext _context;

    public UserController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email","Email already registered");
                return View("../Home/Index");
            }

            if(_context.Users.Any(u => u.UserName == newUser.UserName))
            {
                ModelState.AddModelError("UserName","User Name is already in use");
                return View("../Home/Index");
            }

            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("UserName", newUser.UserName);
            HttpContext.Session.SetInt32("NumCartItems", newUser.Cart.Sum(p => p.OrderedQuantity));
            return RedirectToAction("Dashboard","Home");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpPost]
    public IActionResult Login(LogUser user)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users
            .Include(u => u.Cart)
            .FirstOrDefault(u => u.Email == user.LogEmail);

            if(userInDb == null)
            {
                ModelState.AddModelError("LogPassword","Invalid Email/Password");
                return View("../Home/Index");
            }

            var hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LogPassword","Invalid Email/Password");
                return View("../Home/Index");
            }

            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            HttpContext.Session.SetString("UserName", userInDb.UserName);
            HttpContext.Session.SetInt32("NumCartItems", userInDb.Cart.Sum(p => p.OrderedQuantity));
            return RedirectToAction("Dashboard","Home");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpGet("account")]
    public IActionResult Account()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            User userInDb = _context.Users
            .Include(u => u.UserAddresses)
            .Include(u => u.UserPayments)
            .Include(u => u.SubmittedOrders)
            .ThenInclude(so => so.Products)
            .ThenInclude(piso => piso.Product)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            ViewBag.User = userInDb;
            return View();
        }
        else
        {
            return RedirectToAction("Index","Home");
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}