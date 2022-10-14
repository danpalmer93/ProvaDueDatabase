using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Repository
{
    public class FigureDomandeRep : Repository<FigureDomande>, IFigureDomandeRep
    {
        public FigureDomandeRep(ProvaDueContext Context) : base(Context)
        {
        }
    }
}
