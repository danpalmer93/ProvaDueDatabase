using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;

namespace ProvaDueDatabase.Services
{
    public interface IDomandaService
    {
        public IEnumerable<DomandaDto> GetAll(string? searchText=null);
        public DomandaDto Add(DomandaDto domanda);
        public DomandaDto Remove(DomandaDto domandaDto);

        public DomandaDto FindById (int id);

        public DomandaDto Update ( DomandaDto domandaDto);

        public int  FindIdByTesto(string testo);

        public IEnumerable<DomandaDto> GetAllDefault();
    }
}
