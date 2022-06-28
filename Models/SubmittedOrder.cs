#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class SubmittedOrder
    {
        [Key]
        public int SubmittedOrderId {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int StorefrontId {get; set;}
        public Storefront? Storefront {get; set;}
        public int UserId {get; set;}
        public User? Submitter {get; set;}
        public int ShippingAddressId {get; set;}
        public ShippingAddress? ShippingAddress {get; set;}
        public int PaymentId {get; set;}
        public Payment? Payment {get; set;}
        public List<ProductsInSubmittedOrder> Products {get; set;} = new List<ProductsInSubmittedOrder>();
    }
}