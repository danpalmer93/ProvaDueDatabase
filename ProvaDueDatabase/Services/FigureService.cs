using ProvaDueDatabase.Models;
using ProvaDueDatabase.Repository;

namespace ProvaDueDatabase.Services
{
    public class FigureService : IFiguraService
    {
        private readonly IFiguraRep _figuraRepository;

        public FigureService(IFiguraRep figuraRepository)
        {
            _figuraRepository = figuraRepository;
        }

        public IEnumerable<FiguraDto> GetAll(string? searchText = null)
        {
            IEnumerable<Figura> listaFigure;

            if (string.IsNullOrEmpty(searchText))
            {
                listaFigure = _figuraRepository.GetAll();
            }
            else
            {
                listaFigure = _figuraRepository.Find(figura => figura.Descrizione.Contains(searchText));
            }

            return listaFigure.Select(figura =>
            {
                return new FiguraDto(figura.Id, figura.File, figura.Descrizione);
            });
        }



    }
}
