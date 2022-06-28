#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class Storefront
    {
        [Key]
        public int StorefrontId {get; set;}
        [Required]
        public string Title {get; set;}
        [Required]
        public string Description {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UserId {get; set;}
        public User? Owner {get; set;}
        public List<Product> Inventory {get; set;} = new List<Product>();
        public List<SubmittedOrder> SubmittedOrders {get; set;} = new List<SubmittedOrder>();
    }
}