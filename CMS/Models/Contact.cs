using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Contact
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string BillingAddress { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }
    }
}
