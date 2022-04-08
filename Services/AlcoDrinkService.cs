using AutoMapper;
using FineAlcoAPI.Entities;
using FineAlcoAPI.Exceptions;
using System.Linq;

namespace FineAlcoAPI.Services
{
    public class AlcoDrinkService: IAlcoDrinkService
    {
        private readonly BarDbContext _dbContext;
        private readonly IMapper _mapper;

        public AlcoDrinkService(BarDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public int Create(int barId, AlcoDrinkDto dto)
        {
            var bar = _dbContext
                .Set<Bar>()
                .FirstOrDefault(x => x.Id == barId);
            if (bar == null)
                throw new NotFoundException("Bar not found");

            var AlcoDrinkEntity = _mapper.Map <AlcoDrink>(dto);

            _dbContext.AlcoDrinks.Add(AlcoDrinkEntity);
            _dbContext.SaveChanges();

            return AlcoDrinkEntity.Id;
        }

    }
}
