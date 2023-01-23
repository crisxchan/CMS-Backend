using System.ComponentModel.DataAnnotations;

namespace CMS.DTOs
{
    public class ContactCreateDto
    {
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
