using System.ComponentModel.DataAnnotations;

namespace FineAlcoAPI.Entities
{
    public class AlcoDrinkDto
    {   
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BarId { get; set; }
    }
}
