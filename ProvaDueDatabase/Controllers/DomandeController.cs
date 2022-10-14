using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Repository;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    public class DomandeController : Controller
    {
        private IDomandaService _domandaService;

        public DomandeController(IDomandaService domandaService)
        {
            _domandaService = domandaService;
        }

        public IActionResult Index()
        {
            IEnumerable<DomandaDto> listaDomande = _domandaService.GetAll();
            return View(listaDomande);
        }

        public IActionResult Crea()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(DomandaDto d)
        {
            _domandaService.Add(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Rimuovi(int id)
        {
            DomandaDto domandaDto = new DomandaDto();
            domandaDto.Id = id;
            _domandaService.Remove(domandaDto);
            return RedirectToAction("Index");
        }

        
        public IActionResult Modifica(int id)
        {
            DomandaDto domandaDto = _domandaService.FindById(id);
            return View(domandaDto);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Modifica(DomandaDto domandaDto)
        {
            _domandaService.Update(domandaDto);
            return RedirectToAction("Index");
        }
    }
}
