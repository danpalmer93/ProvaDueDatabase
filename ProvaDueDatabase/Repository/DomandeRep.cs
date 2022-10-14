using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;

namespace ProvaDueDatabase.Repository
{
    public class DomandeRep : Repository<Domanda>, IDomandeRep
    {
        public DomandeRep(ProvaDueContext context) : base(context)
        {

        }

      
    }
}
