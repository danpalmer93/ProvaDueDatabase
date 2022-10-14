using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Services;
using ServiceStack;

namespace ProvaDueDatabase.Controllers
{
    public class FigureDomandeController : Controller
    {
        private IFigureDomandeService _figureDomandeService;
        private IFiguraService _iguraService;
        private IDomandaService _omandaService;


        public FigureDomandeController(IFigureDomandeService figureDomandeService, IFiguraService iguraService, IDomandaService omandaService)
        {
            _figureDomandeService = figureDomandeService;
            _iguraService = iguraService;
            _omandaService = omandaService;
        }

        public IActionResult Index()
        {
            IEnumerable<FigureDomande> lista = _figureDomandeService.GetAll();
            return View(lista);
        }

        public IActionResult Aggiungi()
        {
            IEnumerable<FiguraDto> listaFigure = _iguraService.GetAll();
            IEnumerable<DomandaDto> listaDomande = _omandaService.GetAll();
            MyViewFigure model = new MyViewFigure();
            model.figures = listaFigure;
            model.domande = listaDomande;
            return View(model);
        }

        [HttpPost]
       public IActionResult Aggiungi(MyViewFigure mvm)
        {
            FigureDomande fd = new FigureDomande();
            IEnumerable<FigureDomande> listaFigDom = _figureDomandeService.GetAll().ToList();
            foreach (FigureDomande figureDomande in listaFigDom)
            {
                if(figureDomande.IdFigura == (int)mvm.idFigura)
                {
                    if(figureDomande.IdDomanda== (int)mvm.idDomanda)
                    {
                        Console.WriteLine("ERRORE, STAI INSERENDO UNA DOMANDA GIA INSERITA");
                        ViewData["errore"] = "ATTENZIONE LA DOMANDA è GIA STATA INSERITA NELLA FIGURA";
                        return View("Errore", ViewData["errore"]);
                    }
                    else
                    {
                        fd.IdFigura = (int)mvm.idFigura;
                        fd.IdDomanda = (int)mvm.idDomanda;
                        return RedirectToAction("Index");
                    }
                }

            }
            fd.IdFigura = (int)mvm.idFigura;
            fd.IdDomanda = (int)mvm.idDomanda;
            _figureDomandeService.Add(fd);
            return RedirectToAction("Index");
        }

        public IActionResult Errore()
        {
            return View();
        }
    }
}
