#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [Display(Name ="User Name")]
        public string UserName {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword {get; set;}
        public List<SubmittedOrder> SubmittedOrders {get; set;} = new List<SubmittedOrder>();
        public List<ProductsInCart> Cart {get; set;} = new List<ProductsInCart>();
        public List<Payment> UserPayments {get; set;} = new List<Payment>();
        public List<ShippingAddress> UserAddresses {get; set;} = new List<ShippingAddress>();
    }
}