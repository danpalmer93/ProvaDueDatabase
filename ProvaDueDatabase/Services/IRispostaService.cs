using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Services
{
    public interface IRispostaService
    {
        public IEnumerable<Risposta> GetAll(string? searchText=null);
        public Risposta Add(Risposta risposta);

        public Risposta Add(Risposta risposta, FigureDomande figureDomande);

        public IEnumerable<Risposta> GetAllByPeso();

        public IEnumerable<Risposta> GetAllByIdFD(int idFD);

        public Risposta FindById(int id);

    }
}
