using ProvaDueDatabase.Models;

namespace ProvaDueDatabase.Services
{
    public interface IFiguraService
    {
        public IEnumerable<FiguraDto> GetAll(string? searchText=null);
    }
}
