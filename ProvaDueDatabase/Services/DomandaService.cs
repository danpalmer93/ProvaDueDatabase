using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Repository;

namespace ProvaDueDatabase.Services
{
    public class DomandaService : IDomandaService
    {
        private readonly IDomandeRep domandeRep;

        public DomandaService(IDomandeRep domandeRep)
        {
            this.domandeRep = domandeRep;
        }

        public IEnumerable<DomandaDto> GetAll(string? searchText = null)
        {
            IEnumerable<Domanda> listDomande;

            if (string.IsNullOrEmpty(searchText))
            {
                listDomande = domandeRep.GetAll();
            }
            else
            {
                listDomande = domandeRep.Find(domanda => domanda.Testo.Contains(searchText));
            }

            return listDomande.Select(domanda =>
            {
                return new DomandaDto(domanda.Id, domanda.Testo, null);
            });
        }

        public DomandaDto Add(DomandaDto domandaDto)
        {
            Domanda domanda = new Domanda();
            domanda.Testo = domandaDto.TestoDomanda;
            domanda.Default = domandaDto.Default;
            domandeRep.Add(domanda);
            return domandaDto;
        }



        public DomandaDto Remove(DomandaDto domandaDto)
        {
            int id = domandaDto.Id;
            Domanda domanda = domandeRep.FindById(id);
            domandeRep.Delete(domanda);
            return domandaDto;
        }

        public DomandaDto FindById(int id)
        {
            Domanda domanda = domandeRep.FindById(id);
            DomandaDto domandaDto = new DomandaDto();
            domandaDto.Id = domanda.Id;
            domandaDto.TestoDomanda = domanda.Testo;
            domandaDto.Default = domanda.Default;
            return domandaDto;
        }

        public DomandaDto Update(DomandaDto domandaDto)
        {
            Domanda domanda = domandeRep.FindById(domandaDto.Id);
            domanda.Testo = domandaDto.TestoDomanda;
            domanda.Default = domandaDto.Default;
            domandeRep.Update(domanda);
            return domandaDto;
        }



        public int FindIdByTesto(string testo)
        {
            int idDomanda = 0;
            testo = string.IsNullOrEmpty(testo)?string.Empty : testo.ToLower() ;
            var domande = domandeRep.Find(domanda => domanda.Testo.ToLower().Equals(testo));

            if (domande.Any())
            {
                idDomanda =domande.First().Id;
            }
            return idDomanda;
        }

        public IEnumerable<DomandaDto> GetAllDefault()
        {
            IEnumerable<Domanda> domandeDefault = domandeRep.GetAll().Where(d => d.Default.HasValue).ToList();
            return domandeDefault.Select(domanda =>
            {
                return new DomandaDto(domanda.Id, domanda.Testo, domanda.Default);
            });
        }
    }
}
