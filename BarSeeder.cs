using FineAlcoAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FineAlcoAPI
{
    public class BarSeeder
    {
        private readonly BarDbContext _dbContext;
        public BarSeeder(BarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Bars.Any())
                {
                    var bars = GetBars();
                    _dbContext.Bars.AddRange(bars);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Bar> GetBars()
        {
            var bars = new List<Bar>()
            {
                new Bar()
            {
                Name = "LightBooz",
                Description = "Bar with beer and whiskey",
                Category = "Pub",
                ContactEmail = "lightbooz@gmail.com",
                ContactNumber = "+48759854786",
                AlcoDrinks = new List<AlcoDrink>()
                {
                    new AlcoDrink()
                    {
                        Name="LightBeer",
                        Price= 10.90M,
                        Description="GoodBeer"
                    },
                    new AlcoDrink()
                    {
                        Name="DarkBeer",
                        Price= 12.90M,
                        Description="GoodBeer"
                    },
                    new AlcoDrink()
                    {
                        Name="FruiteBeer",
                        Price= 9.90M,
                        Description="GoodBeer"
                    },
                    new AlcoDrink()
                    {
                        Name="Whiskiey",
                        Price= 29.90M,
                        Description="GoodWhiskiey"
                    }
                },
                Address = new Address()
                {
                    City ="Lublin",
                    Street ="Nadbysrzycka 40",
                    PostalCode="20-974"
                }
            },

                new Bar()
            {
                Name = "HardBooz",
                Description = "Bar with wodka and whiskey",
                Category = "Bar",
                ContactEmail = "hardbooz@gmail.com",
                ContactNumber = "+48983464786",
                AlcoDrinks = new List<AlcoDrink>()
                {
                    new AlcoDrink()
                    {
                        Name="Wodka",
                        Price= 19.90M,
                        Description ="GoodWodka"
                    },
                    new AlcoDrink()
                    {
                        Name="Gin",
                        Price= 25.90M,
                        Description ="Gin"
                    },
                    new AlcoDrink()
                    {
                        Name="LightBeer",
                        Price= 9.90M,
                        Description ="GoodBeer"
                    },
                    new AlcoDrink()
                    {
                        Name="Whiskiey",
                        Price= 29.90M,
                        Description ="GoodWhiskiey"
                    }
                },
                Address = new Address()
                {
                    City = "Lublin",
                    Street = "Nadbysrzycka 40",
                    PostalCode = "20-974"
                }
            }
            };
            return bars;
        }       
    }
}
