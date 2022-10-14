using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Models.ViewModel;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    public class StudenteController : Controller
    {
        private readonly IFiguraService _figuraService;
        private readonly IDomandaService _domandaService;

        public StudenteController(IFiguraService figuraService, IDomandaService domandaService)
        {
            _figuraService = figuraService;
            _domandaService = domandaService;
        }

        public IActionResult Index()
        {
            
            IEnumerable<DomandaDto> listaDomande = _domandaService.GetAllDefault().ToList();
            IEnumerable<FiguraDto> listaFigure = _figuraService.GetAll().ToList();
            ViewModelStudente viewStudente = new ViewModelStudente
            {
                Figura = listaFigure,
                Domanda = listaDomande
            };
            return View(viewStudente);
        }

        public IActionResult Inizio()
        {
            return View();
        }

    }
}
