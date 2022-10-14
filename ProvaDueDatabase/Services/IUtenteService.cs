using ProvaDueDatabase.Models;

namespace ProvaDueDatabase.Services
{
    public interface IUtenteService
    {
        public void Add(Utente u);
        public void Remove(Utente u);

        public IEnumerable<Utente> GetAll();
    }
}
