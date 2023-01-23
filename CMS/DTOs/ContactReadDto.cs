using System.ComponentModel.DataAnnotations;

namespace CMS.DTOs
{
    public class ContactReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
