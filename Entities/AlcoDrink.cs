namespace FineAlcoAPI.Entities
{
    public class AlcoDrink
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BarId { get; set; }

        public virtual Bar Bar { get; set; }  

    }
}
