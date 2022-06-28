#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public decimal Price {get; set;}
        [Required]
        public int Quantity {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int StorefrontId {get; set;}
        public Storefront? HomeStorefront {get; set;}
        public List<ProductsInCart> Carts {get; set;} = new List<ProductsInCart>();
        public List<ProductsInSubmittedOrder> SubmittedOrders {get; set;} = new List<ProductsInSubmittedOrder>();
    }
}