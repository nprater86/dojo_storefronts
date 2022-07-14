using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dojo_storefronts.Models;
namespace dojo_storefronts.Controllers;

public class OrderController : Controller
    {
    private MyContext _context;

    public OrderController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult SubmitOrder(SubmittedOrder submittedOrder)
    {
        User userInDb = _context.Users
        .Include(u => u.Cart)
        .ThenInclude(pic => pic.Product)
        .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

        //get a list of the unique StoreIds in the order
        List<int> StoreIdsInCart = new List<int>();

        foreach(var product in userInDb.Cart) 
        {
            if(!StoreIdsInCart.Any(id => id == product.Product.StorefrontId))
            {
                StoreIdsInCart.Add(product.Product.StorefrontId);
            }
        }

        // Create a new SubmittedOrder for each of the unique store ids found above and add the order to a list of SubmittedOrders
        List<SubmittedOrder> Orders = new List<SubmittedOrder>();

        foreach(int StoreId in StoreIdsInCart) 
        {
            SubmittedOrder newOrder = new SubmittedOrder();
            newOrder.StorefrontId = StoreId;
            newOrder.UserId = (int)HttpContext.Session.GetInt32("UserId");
            newOrder.ShippingAddressId = submittedOrder.ShippingAddressId;
            newOrder.PaymentId = submittedOrder.PaymentId;
            newOrder.Status = "Submitted";
            _context.Add(newOrder);
            _context.SaveChanges();
            Orders.Add(newOrder);
        }

        //go through each order id, and create a ProductInSubmittedOrder for each product in the cart
        foreach(var order in Orders)
        {
            foreach(var product in userInDb.Cart)
            {
                if(product.Product.StorefrontId == order.StorefrontId)
                {
                    ProductsInSubmittedOrder newPISO = new ProductsInSubmittedOrder();
                    newPISO.ProductId = product.ProductId;
                    newPISO.SubmittedOrderId = order.SubmittedOrderId;
                    newPISO.OrderedQuantity = product.OrderedQuantity;
                    _context.Add(newPISO);
                    _context.SaveChanges();
                }
            }
        }

        _context.RemoveRange(userInDb.Cart);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("NumCartItems", 0);

        return RedirectToAction("Dashboard","Home");
    }

    [HttpPost]
    public IActionResult UpdateStatus(SubmittedOrder updatedOrder)
    {
        SubmittedOrder order = _context.SubmittedOrders
        .Include(o => o.Products)
        .ThenInclude(p => p.Product)
        .FirstOrDefault(o => o.SubmittedOrderId == updatedOrder.SubmittedOrderId);

        if((order.Status == "Shipped" || order.Status == "Complete") && (updatedOrder.Status == "Processing" || updatedOrder.Status == "Submitted"))
        {
            foreach(var product in order.Products)
            {
                product.Product.Quantity += product.OrderedQuantity;
                _context.SaveChanges();
            }
        }

        if((order.Status == "Submitted" || order.Status == "Processing") && (updatedOrder.Status == "Shipped" || updatedOrder.Status == "Complete"))
        {
            foreach(var product in order.Products)
            {
                product.Product.Quantity -= product.OrderedQuantity;
                _context.SaveChanges();
            }
        }

        order.Status = updatedOrder.Status;
        order.Carrier = updatedOrder.Carrier;
        order.TrackingNumber = updatedOrder.TrackingNumber;

        _context.SaveChanges();
        
        return RedirectToAction("ManageOrder", "Storefront", new {SubmittedOrderId = updatedOrder.SubmittedOrderId});
    }
}