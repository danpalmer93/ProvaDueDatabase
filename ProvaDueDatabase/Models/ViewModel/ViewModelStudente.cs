using ProvaDueDatabase.Models.Dto;

namespace ProvaDueDatabase.Models.ViewModel
{
    public class ViewModelStudente
    {
        public IEnumerable<FiguraDto> Figura { get; set; }
        public IEnumerable<DomandaDto> Domanda { get; set; }
    }
}
