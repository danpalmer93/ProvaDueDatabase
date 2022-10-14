using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Repository
{
    public class RisposteRep : Repository<Risposta>, IRisposteRepository
    {
        public RisposteRep(ProvaDueContext Context) : base(Context)
        {
        }
    }
}
