#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class ProductsInCart
    {
        [Key]
        public int ProductsInCartId {get; set;}
        public int ProductId {get; set;}
        public Product? Product {get; set;}
        public int UserId {get; set;}
        public User? Owner {get; set;}
        public int OrderedQuantity {get; set;}
    }
}