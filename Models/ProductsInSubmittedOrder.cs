#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class ProductsInSubmittedOrder
    {
        [Key]
        public int ProductsInSubmittedOrderId {get; set;}
        
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public int SubmittedOrderId {get; set;}
        public SubmittedOrder SubmittedOrder {get; set;}
        public int OrderedQuantity {get; set;}
    }
}