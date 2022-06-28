#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class MyStorefrontViewModel
    {
        public Storefront Storefront {get; set;}
        public Product Product {get; set;}
    }
}