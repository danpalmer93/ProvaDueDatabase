using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Models.ViewModel;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IFiguraService _figuraService;
        private readonly IDomandaService _domandaService;
        private readonly IFigureDomandeService _figureDomandeService;
        private readonly IRispostaService rispostaService;

        public DocenteController(IFiguraService figuraService, IDomandaService domandaService, IFigureDomandeService figureDomandeService, IRispostaService rispostaService)
        {
            _figuraService = figuraService;
            _domandaService = domandaService;
            _figureDomandeService = figureDomandeService;
            this.rispostaService = rispostaService;
        }

        public IActionResult Index()
        {
            List<Risposta> listaRisposteDefault = rispostaService.GetAllByPeso().ToList();
            List<FiguraDto> listaFigure = _figuraService.GetAll().ToList();
            ViewModelDocente viewModelDocente = new ViewModelDocente();
            viewModelDocente.ListaRisposte = listaRisposteDefault;
            viewModelDocente.Figura = listaFigure;
            return View(viewModelDocente);
        }

        public IActionResult Aggiungi(ViewModelDocente viewMDocente)
        {
            var idFigura = viewMDocente.idFigura;
            var testoDomanda = viewMDocente.testoDomanda;
            var risposta = viewMDocente.risposta;

            if (string.IsNullOrEmpty(risposta))
            {
                ViewData["errore"] = "Attenzione non hai inserito nessuna risposta";
                List<Risposta> listaRisposteDefault = rispostaService.GetAllByPeso().ToList();
                List<FiguraDto> listaFigure = _figuraService.GetAll().ToList();
                ViewModelDocente viewModelDocente = new ViewModelDocente();
                viewModelDocente.ListaRisposte = listaRisposteDefault;
                viewModelDocente.Figura = listaFigure;
                return View("Index", viewModelDocente);
            }

            FigureDomande figureDomande = new FigureDomande();
            if (_domandaService.FindIdByTesto(testoDomanda) != 0)
            {
                figureDomande.IdDomanda = _domandaService.FindIdByTesto(testoDomanda);
                figureDomande.IdFigura = idFigura;
            }
            else
            {
                if (string.IsNullOrEmpty(testoDomanda))
                {
                    ViewData["errore"] = "Attenzione non è stata fatta ancora nessuna domanda";
                    List<Risposta> listaRisposteDefault = rispostaService.GetAllByPeso().ToList();
                    List<FiguraDto> listaFigure = _figuraService.GetAll().ToList();
                    ViewModelDocente viewModelDocente = new ViewModelDocente();
                    viewModelDocente.ListaRisposte = listaRisposteDefault;
                    viewModelDocente.Figura = listaFigure;
                    return View("Index", viewModelDocente);
                }
                DomandaDto nuovaDomanda = new DomandaDto(testoDomanda, null);
                _domandaService.Add(nuovaDomanda);
                int idNuovaDomanda = _domandaService.FindIdByTesto(testoDomanda);
                figureDomande.IdDomanda = idNuovaDomanda;
                figureDomande.IdFigura = idFigura;
            }

            if (_figureDomandeService.Controllo(figureDomande) == false)
            {
                _figureDomandeService.Add(figureDomande);
            }



            Risposta entityRisposta = new Risposta();
            entityRisposta.TestoRisposta = risposta;
            if (_figureDomandeService.Trova(figureDomande.IdFigura, figureDomande.IdDomanda) != 0)
            {
                entityRisposta.IdFiguraDomanda = _figureDomandeService.Trova(figureDomande.IdFigura, figureDomande.IdDomanda);
                rispostaService.Add(entityRisposta);
            }

            return RedirectToAction("Index");
        }


    }
}
