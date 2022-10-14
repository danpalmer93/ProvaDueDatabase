using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models;

namespace ProvaDueDatabase.Repository
{
    public class FiguraRep : Repository<Figura>, IFiguraRep
    {
        public FiguraRep(ProvaDueContext Context) : base(Context)
        {
        }


    }
}
