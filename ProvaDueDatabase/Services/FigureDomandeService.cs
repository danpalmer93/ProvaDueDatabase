using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Repository;

namespace ProvaDueDatabase.Services
{
    public class FigureDomandeService : IFigureDomandeService
    {
       private readonly IFigureDomandeRep figureDomandeRep;

        public FigureDomandeService(IFigureDomandeRep figureDomandeRep)
        {
            this.figureDomandeRep = figureDomandeRep;
        }

        public FigureDomande Add(FigureDomande figureDomande)
        {
            figureDomandeRep.Add(figureDomande);
            return figureDomande;
        }

        public IEnumerable<FigureDomande> GetAll()
        {
            IEnumerable<FigureDomande> lista =  figureDomandeRep.GetAll();
            return lista;
        }

        public Boolean Controllo(FigureDomande fg)
        {
            Boolean a = false;
            
            List<FigureDomande> listaFg = figureDomandeRep.GetAll().ToList();
            foreach(var item in listaFg)
            {
                if (item.IdDomanda.Equals(fg.IdDomanda) && item.IdFigura.Equals(fg.IdFigura))
                {
                    a=true;
                } 
            }
            return a;
        }

        public int Trova(int idFigura, int idDomanda)
        {
            int idFiguraDomanda = 0;
            List<FigureDomande> figureDomandes = figureDomandeRep.GetAll().ToList();

            foreach(var item in figureDomandes)
            {
                if (item.IdDomanda.Equals(idDomanda) && item.IdFigura.Equals(idFigura))
                {
                    idFiguraDomanda = item.Id;
                }
            }
            return idFiguraDomanda;
        }
    }
}
