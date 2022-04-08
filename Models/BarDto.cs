using System.Collections.Generic;

namespace FineAlcoAPI.Models
{
    public class BarDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        //public List<AlcoDrinkDto> AlcoDrinks {get; set;}
    }
}
