using System.ComponentModel.DataAnnotations;

namespace FineAlcoAPI.Models
{
    public class CreateBarDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string ContactEmail { get; set; }

        public string ContactNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        public string PostalCode { get; set; }
    }
}
