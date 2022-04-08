using FineAlcoAPI.Models;
using System.Collections.Generic;

namespace FineAlcoAPI.Services
{
    public interface IBarService
    {
        public BarDto GetById(int id);
        public IEnumerable<BarDto> GetAll();
        public int CreateBar(CreateBarDto dto);
        public void DeleteBar(int id);
        public void UpdateBar (BarUpdateDto dto, int id);
        public BarDto GetByName(string name);
    }
}
