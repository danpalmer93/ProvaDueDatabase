using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Services
{
    public interface IFigureDomandeService
    {
        public IEnumerable<FigureDomande> GetAll();

        public FigureDomande Add(FigureDomande figureDomande);

        public Boolean Controllo(FigureDomande figureDomande);

        public int Trova(int idFigura, int idDomanda);

        
    }
}
