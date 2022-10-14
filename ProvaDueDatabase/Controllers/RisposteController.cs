using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    
    public class RisposteController : Controller
    {
        private readonly IRispostaService _risposteService;

        public RisposteController(IRispostaService risposteService)
        {
            _risposteService = risposteService;
        }

        public IActionResult Index()
        {
            IEnumerable<Risposta> listaRisposte = _risposteService.GetAll();
            return View(listaRisposte);
        }

        public IActionResult Aggiungi()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Aggiungi(Risposta r)
        {
            _risposteService.Add(r);
            return RedirectToAction("Index");
        }
    }
}
