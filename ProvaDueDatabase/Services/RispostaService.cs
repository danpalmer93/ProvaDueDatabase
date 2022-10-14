using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Repository;

namespace ProvaDueDatabase.Services
{
    public class RispostaService : IRispostaService
    {
        private readonly IRisposteRepository _repository;

        public RispostaService(IRisposteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Risposta> GetAll(string? searchText = null)
        {
            IEnumerable<Risposta> listaRisposte;
            if (string.IsNullOrEmpty(searchText))
            {
                listaRisposte = _repository.GetAll();
            }
            else
            {
                listaRisposte = _repository.Find(risp => risp.TestoRisposta.Contains(searchText));
            }

            return listaRisposte.ToList();
        }

        public Risposta Add(Risposta risposta)
        {
            try
            {
                _repository.Add(risposta);
                return risposta;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Risposta Add(Risposta risposta, FigureDomande figureDomande)
        {
            risposta.IdFiguraDomanda = figureDomande.Id;
            _repository.Add(risposta);
            return risposta;
        }

        public IEnumerable<Risposta> GetAllByPeso()
        {
            IEnumerable<Risposta> listaRisposte = _repository.GetAll()
                .Where(r => r.Peso > 10)
                .OrderBy(r => r.Peso);

            return listaRisposte;
        }

        // ritorna la lista delle risposte in base al collegamento della tabella figure domande
        public IEnumerable<Risposta> GetAllByIdFD(int idFD)
        {
            IEnumerable<Risposta> lista = _repository.GetAll()
                .Where(r=>r.IdFiguraDomanda==idFD)
                .OrderByDescending(r=>r.Peso)
                .ToList();
           
            
            return lista;
        }

        public Risposta FindById(int id)
        {
            try
            {
                return _repository.FindById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
