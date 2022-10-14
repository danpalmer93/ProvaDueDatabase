using ProvaDueDatabase.Models;
using ProvaDueDatabase.Repository;

namespace ProvaDueDatabase.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRep _utenteRep;

        public UtenteService(IUtenteRep utenteRep)
        {
            _utenteRep = utenteRep;
        }

        public void Add(Utente u)
        {
            try
            {
                _utenteRep.Add(u);
                
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public void Remove(Utente u)
        {
            try
            {
                _utenteRep.Delete(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public IEnumerable<Utente> GetAll()
        {
            return _utenteRep.GetAll().ToList();
        }
    }
}
