using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Models.ViewModel
{
    public class ViewModelDocente
    {
        public IEnumerable<FiguraDto> Figura { get; set; }

        public int idFigura { get; set; }

        public string testoDomanda { get; set; }

        public string risposta { get; set; }

        public IEnumerable<Risposta> ListaRisposte { get; set; }
    }
}
