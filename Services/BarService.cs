using FineAlcoAPI.Entities;
using FineAlcoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using FineAlcoAPI.Exceptions;

namespace FineAlcoAPI.Services
{
    public class BarService : IBarService
    {
        private readonly BarDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BarService> _logger;

        public BarService(BarDbContext dbContext, IMapper mapper, ILogger<BarService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public BarDto GetById(int id)
        {
            var bar = _dbContext
                .Set<Bar>()
                .Include(x => x.AlcoDrinks)
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Id == id);

            var barDto = _mapper.Map<BarDto>(bar);

            if (bar == null)
                throw new NotFoundException("Bar not found");
            return barDto;

        }

        public IEnumerable<BarDto> GetAll()
        {
            var bars = _dbContext
                .Set<Bar>()
                .Include(x => x.AlcoDrinks)
                .Include(x => x.Address)
                .ToList();

            var barDtos = _mapper.Map<List<BarDto>>(bars);
            return barDtos;
        }

        public BarDto GetByName(string name)
        {
            var bar = _dbContext
              .Set<Bar>()
              .Include(x => x.AlcoDrinks)
              .Include(x => x.Address)
              .FirstOrDefault(x => x.Name.Contains(name));

            var barDto = _mapper.Map<BarDto>(bar);

            if (bar == null)
                throw new NotFoundException("Bar not found");
            return barDto;
        }

        public int CreateBar(CreateBarDto dto)
        {
            var createdBar = _mapper.Map<Bar>(dto);

            _dbContext.Bars.Add(createdBar);
            _dbContext.SaveChanges();
            return createdBar.Id;
        }

        public void DeleteBar(int id)
        {
            _logger.LogError($"Bar with {id} DELETE action invoked");

            var bar = _dbContext
                .Set<Bar>()
                .FirstOrDefault(x => x.Id == id);

            if (bar == null)
                throw new NotFoundException("Bar not found");

            _dbContext.Bars.Remove(bar);
            _dbContext.SaveChanges();
        }

        public void UpdateBar(BarUpdateDto dto, int id)
        {
            var bar = _dbContext
                .Set<Bar>()
                .FirstOrDefault(x => x.Id == id);

            if (bar == null)
                throw new NotFoundException("Bar not found");

            bar.Name = dto.Name;
            bar.Description = dto.Description;
            bar.Category = dto.Category;

            _dbContext.SaveChanges();
        }
    }
}
