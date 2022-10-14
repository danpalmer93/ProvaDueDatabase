using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models.Enity;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RispostaApiController : ControllerBase
    {
        private readonly IRispostaService rispostaService;

        public RispostaApiController(IRispostaService rispostaService)
        {
            this.rispostaService = rispostaService;
        }

        [HttpGet("{id}")]

        public JsonResult getRisposta(int id)
        {
            Risposta risposta = rispostaService.FindById(id);

            return new JsonResult(risposta);
        }
    }
}
