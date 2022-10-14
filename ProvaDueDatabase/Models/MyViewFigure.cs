using ProvaDueDatabase.Models.Dto;

namespace ProvaDueDatabase.Models
{
    public class MyViewFigure
    {
        public IEnumerable<FiguraDto> figures { get; set; }

        public IEnumerable<DomandaDto> domande { get; set; }

        public int? @idFigura { get; set; }

        public int? @idDomanda { get; set; }
    }
}
