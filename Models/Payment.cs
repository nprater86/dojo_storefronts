#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dojo_storefronts.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId {get; set;}
        public string? Name {get; set;} = null;
        [Required]
        public string NameOnCard {get; set;}
        [Required]
        public string Company {get; set;}
        [Required]
        public string Number {get; set;}
        [Required]
        public DateTime Expiration {get; set;}
        [Required]
        public int CVV {get; set;}
        [Required]
        [DataType(DataType.PostalCode)]
        public int Zipcode {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UserId {get; set;}
        public User? Owner {get; set;}
    }
}