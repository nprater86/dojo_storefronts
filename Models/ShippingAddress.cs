#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class ShippingAddress
    {
        [Key]
        public int ShippingAddressId {get; set;}
        public string? Name {get; set;} = null;
        [Required]
        public string  NameOnPackage {get; set;}
        [Required]
        public string Address1 {get; set;}
        public string? Address2 {get; set;} = null;
        [Required]
        public string City {get; set;}
        [Required]
        public string State {get; set;}
        [Required]
        public int Zipcode {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UserId {get; set;}
        public User? User {get; set;}
    }
}