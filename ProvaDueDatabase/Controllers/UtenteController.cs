using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        public void Aggiungi(Utente u)
        {
            _utenteService.Add(u);
        }

        [HttpDelete]
        public void Delete(Utente u)
        {
            _utenteService.Remove(u);
        }

        [HttpGet]
        public JsonResult getAll()
        {
            List<Utente> listUtenti;

            try
            {
                listUtenti = _utenteService.GetAll().ToList();   
            } catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

            return new JsonResult(listUtenti.ToArray());
        }
    }
}
