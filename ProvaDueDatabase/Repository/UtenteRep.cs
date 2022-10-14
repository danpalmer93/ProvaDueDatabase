using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models;

namespace ProvaDueDatabase.Repository
{
    public class UtenteRep : Repository<Utente>, IUtenteRep
    {
        public UtenteRep(ProvaDueContext Context) : base(Context)
        {
        }
    }
}
