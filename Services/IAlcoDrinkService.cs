using FineAlcoAPI.Entities;

namespace FineAlcoAPI.Services
{
    public interface IAlcoDrinkService
    {
        public int Create(int barId, AlcoDrinkDto dto);
    }
}
